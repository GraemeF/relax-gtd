using Autofac.Builder;

namespace Relax.Infrastructure.Services.Interfaces
{
    public interface IRelaxModule
    {
        void RegisterComponents(ContainerBuilder containerBuilder);
        void Compose();
    }
}