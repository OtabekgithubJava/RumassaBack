using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rumassa.Application.Abstractions;
using Rumassa.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IRumassaDbContext, RumassaDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
