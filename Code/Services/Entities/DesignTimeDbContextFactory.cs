using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BugDbContext>
    {
        public BugDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BugDbContext>();
            var connectionString = configuration.GetConnectionString("BugDbConnStr");
            builder.UseSqlServer(connectionString);
            return new BugDbContext(builder.Options);
        }
    }
}
