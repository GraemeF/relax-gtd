using System.Collections.ObjectModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can have notes attached to it.
    /// </summary>
    public interface INotes
    {
        ObservableCollection<INote> Notes { get; }
    }
}