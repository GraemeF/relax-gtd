using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionPresenter))]
    public class ActionPresenter : Presenter, IActionPresenter
    {
        private readonly IAction _action;
        private PropertyObserver<IAction> _actionObserver;

        public ActionPresenter(IAction action)
        {
            _action = action;

            _actionObserver = new PropertyObserver<IAction>(_action).RegisterHandler(x => x.Title, y => DisplayName = y.Title);
            DisplayName = _action.Title;
        }
    }
}