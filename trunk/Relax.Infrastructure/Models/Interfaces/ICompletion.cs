using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be completed.
    /// </summary>
    public interface ICompletable : INotifyPropertyChanged
    {
        DateTime? CompletedDate { get; set; }
    }
}