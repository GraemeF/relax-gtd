using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;
using Relax.Views;

namespace Relax.Presenters
{
    [PerRequest(typeof (IInboxActionsPresenter))]
    [View(typeof (ActionsView))]
    public class InboxActionsPresenter : ListPresenter<IAction, IActionPresenter>, IInboxActionsPresenter
    {
        public InboxActionsPresenter(IWorkspace workspace,
                                     Func<IAction, IActionPresenter> actionPresenterFactory)
            : base(GetFilteredView(workspace.Actions), actionPresenterFactory)
        {
        }

        private static ICollectionView GetFilteredView(ObservableCollection<IAction> actions)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(actions);
            view.Filter = action => ((IAction) action).ActionState == State.Inbox;

            return view;
        }
    }
}