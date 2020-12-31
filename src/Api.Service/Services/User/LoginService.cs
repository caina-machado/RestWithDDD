using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using src.Api.Domain.DTOs;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces.Repositories;
using src.Api.Domain.Interfaces.Services.User;
using src.Api.Domain.Security;

namespace src.Api.Service.Services.User
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SigninConfigurations _signinConfigurations;
        private TokenConfiguration _tokenConfiguration;
        private IConfiguration _configuration;

        public LoginService(
            IUserRepository repository,
            SigninConfigurations signinConfigurations,
            TokenConfiguration tokenConfiguration,
            IConfiguration configuration)
        {
            _repository = repository;
            _signinConfigurations = signinConfigurations;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDTO login)
        {
            var baseUser = new UserEntity();

            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                baseUser = await _repository.FindByLogin(login.Email);

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Authentication failed"
                    };
                }

                ClaimsIdentity identity = CreateIdentity(baseUser);

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();

                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token, login);
            }

            return null;
        }

        private ClaimsIdentity CreateIdentity(UserEntity user)
        {
            return new ClaimsIdentity(
                new GenericIdentity(user.Email),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                }
            );
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO login)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = login.Email,
                message = "Successful login"
            };
        }
    }
}
