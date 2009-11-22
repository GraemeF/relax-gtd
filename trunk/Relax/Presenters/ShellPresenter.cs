using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IShellPresenter))]
    public class ShellPresenter : MultiPresenter, IShellPresenter
    {
        public ShellPresenter(IContextsPresenter contextsPresenter)
        {
            Contexts = contextsPresenter;
        }

        public IContextsPresenter Contexts { get; private set; }
    }
}