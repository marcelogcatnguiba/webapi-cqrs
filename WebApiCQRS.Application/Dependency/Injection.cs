using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WebApiCQRS.Application.Mappings;

namespace WebApiCQRS.Application.Dependency
{
    public static class Injection
    {
        public static IServiceCollection ApplicationInjection(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(DTOToDomainMap));
            service.AddMediatR(conf => { conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });

            return service;
        }
    }
}