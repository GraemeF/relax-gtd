using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Interfaces
{
    /// <summary>
    /// Provides properties that are common to many types of item.
    /// </summary>
    public interface IItem : INotifyPropertyChanged
    {
        string Title { get; set; }
        DateTime Created { get; set; }
        int Id { get; }
    }
}