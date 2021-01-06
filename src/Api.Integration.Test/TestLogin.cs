using System.Threading.Tasks;
using Xunit;

namespace src.Api.Integration.Test
{
    public class TestLogin : BaseIntegration
    {
        [Fact]
        public async Task TestTokenLogin()
        {
            await AddToken();
        }
    }
}
