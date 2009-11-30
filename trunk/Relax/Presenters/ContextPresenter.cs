using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IGtdContextPresenter))]
    public class ContextPresenter : Presenter, IGtdContextPresenter
    {
        #region Delegates

        public delegate IGtdContextPresenter Factory(IGtdContext context);

        #endregion

        public ContextPresenter(IGtdContext context)
        {
            Context = context;
        }

        public IGtdContext Context { get; private set; }
    }
}