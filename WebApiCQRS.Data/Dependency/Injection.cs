using Microsoft.Extensions.DependencyInjection;
using WebApiCQRS.Data.Context;
using WebApiCQRS.Data.Repository;
using WebApiCQRS.Domain.Interfaces;

namespace WebApiCQRS.Data.Dependency
{
    public static class Injection
    {
        public static IServiceCollection DataInjection(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}