using System.Collections.ObjectModel;
using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Models
{
    internal class ItemNotes : Model, INotes
    {
        #region INotes Members

        public ObservableCollection<INote> Notes { get; private set; }

        #endregion
    }
}