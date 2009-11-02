using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be deferred until later.
    /// </summary>
    public interface IDeferral : INotifyPropertyChanged
    {
        DateTime DeferUntil { get; set; }
    }
}