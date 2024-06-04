using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rumassa.Application.UseCases.AuthService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
