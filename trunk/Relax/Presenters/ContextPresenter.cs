using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IGtdContextPresenter))]
    public class ContextPresenter : Presenter, IGtdContextPresenter
    {
        private bool _isReadOnly;

        public ContextPresenter(IGtdContext context)
        {
            Model = context;
            _isReadOnly = true;
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (_isReadOnly != value)
                {
                    _isReadOnly = value;
                    NotifyOfPropertyChange("IsReadOnly");
                }
            }
        }

        #region IGtdContextPresenter Members

        public IGtdContext Model { get; private set; }

        #endregion

        public void Rename()
        {
            IsReadOnly = false;
        }

        public void FinishRename()
        {
            IsReadOnly = true;
        }
    }
}