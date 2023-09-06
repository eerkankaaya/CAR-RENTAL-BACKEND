using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void LOad(IServiceCollection serviceCollection);


    }
}
