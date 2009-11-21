using System.ComponentModel.Composition;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Export(typeof (IContextsPresenter))]
    public class ContextsPresenter : Presenter, IContextsPresenter
    {
        public override string ToString()
        {
            return "Hello from ContextsPresenter";
        }
    }
}