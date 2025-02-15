using _2Core.Interfaces.Infra.Database;
using _3Infra.Database.Repositories;
using _3Infra.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _3Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitWork, UnitWork>();


            services.AddDbContext<DataContext>(opt =>
            {
                // opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                opt.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
            });
            return services;
        }
    }
}
