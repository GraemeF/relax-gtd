using System;
using System.ComponentModel.Composition;
using Autofac.Builder;
using Relax.Infrastructure.Services.Interfaces;

namespace Relax.FileBackingStore
{
    [Export(typeof(IRelaxModule))]
    public class Module : IRelaxModule
    {
        #region IRelaxModule Members

        public void RegisterComponents(ContainerBuilder containerBuilder)
        {
            throw new NotImplementedException();
        }

        public void Compose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}