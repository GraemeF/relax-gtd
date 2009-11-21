using System.Collections.ObjectModel;
using System.ComponentModel;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [PerRequest(typeof (INotes))]
    internal class ItemNotes : INotes
    {
        #region INotes Members

        public ObservableCollection<INote> Notes { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}