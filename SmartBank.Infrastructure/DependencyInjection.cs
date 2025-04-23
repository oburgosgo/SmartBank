using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBank.Application.Interfaces;
using SmartBank.Application.Services;
using SmartBank.Infrastructure.Persistence;
using SmartBank.Infrastructure.Repositories;

namespace SmartBank.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(config.GetConnectionString("SmartBankConnection")));

            
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}