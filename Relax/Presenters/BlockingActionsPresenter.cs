using System;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Views;
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
            : base(blockedAction.BlockingActions, actionPresenterFactory)
        {
        }
    }
}