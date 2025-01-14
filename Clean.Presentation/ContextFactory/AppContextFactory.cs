using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clean.Presentation.ContextFactory
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>()
           .UseSqlServer(configuration.GetConnectionString("Default"),
            b => b.MigrationsAssembly("Clean.Presentation"));
            return new AppDbContext(builder.Options);
        }
    }
}