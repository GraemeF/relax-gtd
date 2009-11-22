using Autofac.Builder;

namespace Relax.Infrastructure.Services.Interfaces
{
    public interface IRelaxModule
    {
        void Initialize(ContainerBuilder builder);
    }
}