using Microsoft.Extensions.DependencyInjection;
using WebApiCQRS.Application.Dependency;
using WebApiCQRS.Data.Context;
using WebApiCQRS.Data.Dependency;

namespace WebApiCQRS.IoC.Dependency
{
    public static class Injection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service)
        {
            service.DataInjection();
            service.ApplicationInjection();

            return service;
        }

        public static void AddDataBase(this IServiceProvider service)
        {
            var serviceScope = service.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<ApiContext>();
            dataContext?.Database.EnsureCreated();
        }
    }
}