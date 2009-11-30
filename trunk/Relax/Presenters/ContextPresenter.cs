using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IContextPresenter))]
    public class ContextPresenter : Presenter, IContextPresenter
    {
        #region Delegates

        public delegate IContextPresenter Factory(IContext context);

        #endregion

        public ContextPresenter(IContext context)
        {
            Context = context;
        }

        public IContext Context { get; private set; }
    }
}