using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IContextsPresenter))]
    public class ContextsPresenter : Presenter, IContextsPresenter
    {
        public override string ToString()
        {
            return "Hello from ContextsPresenter";
        }
    }
}