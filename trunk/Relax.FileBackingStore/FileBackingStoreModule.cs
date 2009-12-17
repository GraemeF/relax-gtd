using System.ComponentModel.Composition;
using Autofac.Builder;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;
using Relax.Infrastructure.Services.Interfaces;

namespace Relax.FileBackingStore
{
    [Export(typeof (IRelaxModule))]
    internal class FileBackingStoreModule : Module, IRelaxModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(new DefaultWorkspaceFileLocator()).As<IStartupFileLocator>();
        }
    }
}