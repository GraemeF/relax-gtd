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
            Context = context;
            _isReadOnly = true;
        }

        public IGtdContext Context { get; private set; }

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