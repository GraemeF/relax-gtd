using System;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionsPresenter))]
    public class ActionsPresenter : PresenterManager, IActionsPresenter
    {
        private readonly Func<IAction, IActionPresenter> _contextPresenterFactory;
        private readonly IWorkspace _workspace;

        public ActionsPresenter(IWorkspace workspace,
                                Func<IAction, IActionPresenter> contextPresenterFactory)
        {
            _workspace = workspace;
            _contextPresenterFactory = contextPresenterFactory;
        }
    }
}