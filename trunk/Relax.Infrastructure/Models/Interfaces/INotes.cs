using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can have notes attached to it.
    /// </summary>
    public interface INotes : INotifyPropertyChanged
    {
        ObservableCollection<INote> Notes { get; }
    }
}