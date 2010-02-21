using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Provides properties that are common to many types of item.
    /// </summary>
    public interface IItem : INotifyPropertyChanged
    {
        string Title { get; set; }
        DateTime Created { get; }
    }
}