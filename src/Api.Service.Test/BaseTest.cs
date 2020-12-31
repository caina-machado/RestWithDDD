using System;
using AutoMapper;
using src.Api.CrossCutting.Mapping;

namespace src.Api.Service.Test
{
    public abstract class BaseTest
    {
        public IMapper Mapper { get; set; }

        public BaseTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DTOToModelProfile());
                cfg.AddProfile(new EntityToDTOProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {

        }
    }
}
