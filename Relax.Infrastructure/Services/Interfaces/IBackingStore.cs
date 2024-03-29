﻿using System.ComponentModel;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Infrastructure.Services.Interfaces
{
    public interface IBackingStore : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <returns></returns>
        IWorkspace Workspace { get; }

        /// <summary>
        /// Loads the model.
        /// </summary>
        void Load();

        /// <summary>
        /// Saves the model.
        /// </summary>
        void Save();

        void Initialize();
    }
}