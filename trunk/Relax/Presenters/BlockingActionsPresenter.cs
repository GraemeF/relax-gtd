using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;
using Relax.Views;

namespace Relax.Presenters
{
    [PerRequest(typeof (IBlockingActionsPresenter))]
    [View(typeof (ActionsView))]
    public class BlockingActionsPresenter : ListPresenter<IAction, IActionPresenter>, IBlockingActionsPresenter
    {
        public BlockingActionsPresenter(IAction blockedAction,
                                        Func<IAction, IActionPresenter> actionPresenterFactory)
            : base(GetFilteredView(blockedAction.BlockingActions), actionPresenterFactory)
        {
        }

        private static ICollectionView GetFilteredView(ObservableCollection<IAction> actions)
        {
            return CollectionViewSource.GetDefaultView(actions);
        }
    }
}