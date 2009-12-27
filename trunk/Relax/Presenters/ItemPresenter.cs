using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Presenters
{
    public abstract class ItemPresenter<TItem> : Presenter where TItem : IItem
    {
        private PropertyObserver<TItem> _itemObserver;

        public ItemPresenter(TItem item)
        {
            Model = item;

            _itemObserver = new PropertyObserver<TItem>(Model).RegisterHandler(x => x.Title,
                                                                               y => NotifyOfPropertyChange("DisplayName"));
            DisplayName = Model.Title;
        }

        public TItem Model { get; private set; }

        public override string DisplayName
        {
            get { return Model.Title; }
            set { Model.Title = value; }
        }
    }
}