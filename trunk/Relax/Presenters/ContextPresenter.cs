using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IGtdContextPresenter))]
    public class ContextPresenter : ItemPresenter<IGtdContext>, IGtdContextPresenter
    {
        private bool _isReadOnly;

        public ContextPresenter(IGtdContext context) : base(context)
        {
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