using System.IO;
using ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClinicaVivaEstetica.WebApi.Utils
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Context>();
            var connectionString = configuration.GetConnectionString("SQLServerConnectionString");
            builder.UseSqlServer(connectionString);
            return new Context(builder.Options);
        }
    }
}