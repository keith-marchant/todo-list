using System.Reflection;
using InfoTrack.Common.Application;
using Microsoft.Extensions.DependencyInjection;

namespace TodoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommonApplication(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
