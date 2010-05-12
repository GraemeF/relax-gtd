using Caliburn.Core.IoC;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionTreeNodePresenter))]
    public class ActionTreeNodePresenter : ActionPresenter, IActionTreeNodePresenter
    {
        public ActionTreeNodePresenter(IAction model, IBlockingActionsPresenter blockingActionsPresenter)
            : base(model)
        {
            BlockingActions = blockingActionsPresenter;
        }

        #region IActionTreeNodePresenter Members

        public IBlockingActionsPresenter BlockingActions { get; private set; }

        #endregion
    }
}