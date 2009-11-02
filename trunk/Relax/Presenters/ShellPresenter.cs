using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IShellPresenter))]
    public class ShellPresenter : Presenter, IShellPresenter
    {
    }
}