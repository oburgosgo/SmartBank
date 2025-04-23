using Microsoft.Extensions.DependencyInjection;
using SmartBank.Application.Interfaces;
using SmartBank.Application.Mappings;
using SmartBank.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(ClientProfile).Assembly);

            
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
