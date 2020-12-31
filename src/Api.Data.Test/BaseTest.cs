using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src.Api.Data.Context;

namespace src.Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest() { }
    }

    public class DbTest : IDisposable
    {
        private string dataBaseName = $"ddd_api_db_test_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(option =>
                option.UseMySql($"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=developer;Password=7654321"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();

            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
