using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Presenters
{
    public abstract class ItemPresenter<TItem> : Presenter where TItem : IItem
    {
        protected bool _isReadOnly;
        private PropertyObserver<TItem> _itemObserver;

        public ItemPresenter(TItem item)
        {
            _isReadOnly = true;
            Model = item;

            _itemObserver = new PropertyObserver<TItem>(Model).RegisterHandler(x => x.Title,
                                                                               y =>
                                                                               NotifyOfPropertyChange("DisplayName"));
            DisplayName = Model.Title;
        }

        public TItem Model { get; private set; }

        public override string DisplayName
        {
            get { return Model.Title; }
            set
            {
                Model.Title = value;
                NotifyOfPropertyChange("DisplayName");
            }
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