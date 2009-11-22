using System.ComponentModel.Composition;
using Autofac.Builder;
using Relax.Infrastructure.Services.Interfaces;

namespace Relax.FileBackingStore
{
    [Export(typeof (IRelaxModule))]
    public class Module : IRelaxModule
    {
        #region IRelaxModule Members

        public void Initialize(ContainerBuilder builder)
        {
        }

        #endregion
    }
}