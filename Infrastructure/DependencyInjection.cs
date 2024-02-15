using Application;
using Application.InterfaceRepository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, string databaseConnectionString)
        {
            services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(databaseConnectionString).EnableSensitiveDataLogging());
            /*services.AddStackExchangeRedisCache(options => options.Configuration = cacheConnectionString);*/
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();   
            services.AddScoped<ISongRepository, SongRepository>();
            return services;
        }
    }
}
