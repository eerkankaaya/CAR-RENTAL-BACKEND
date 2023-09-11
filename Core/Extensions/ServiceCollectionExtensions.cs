using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{//hizmet koleksiyon uzantıları
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,

            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {

                module.LOad(serviceCollection);

            }

            return ServiceTool.Create(serviceCollection);
        }

    }

}
