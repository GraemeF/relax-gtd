using System.ComponentModel;

namespace Relax.Tests.Presenters
{
    public interface ISingleSelector<TItem>:INotifyPropertyChanged
    {
        TItem SelectedItem { get; set; }
    }
}