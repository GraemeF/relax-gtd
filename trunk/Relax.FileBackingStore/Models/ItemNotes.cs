﻿using System.Collections.ObjectModel;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [PerRequest(typeof (INotes))]
    internal class ItemNotes : Model, INotes
    {
        #region INotes Members

        public ObservableCollection<INote> Notes { get; private set; }

        #endregion
    }
}