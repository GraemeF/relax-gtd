using System;
using System.Windows.Data;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionsPresenter))]
    public class ActionsPresenter : ListPresenter<IAction, IActionPresenter>, IActionsPresenter
    {
        public ActionsPresenter(IWorkspace workspace,
                                Func<IAction, IActionPresenter> actionPresenterFactory)
            : base(CollectionViewSource.GetDefaultView(workspace.Actions), actionPresenterFactory)
        {
        }
    }
}