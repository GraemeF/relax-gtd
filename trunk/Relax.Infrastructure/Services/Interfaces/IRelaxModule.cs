using Autofac;

namespace Relax.Infrastructure.Services.Interfaces
{
    public interface IRelaxModule
    {
        void Initialize(IContainer container);
    }
}