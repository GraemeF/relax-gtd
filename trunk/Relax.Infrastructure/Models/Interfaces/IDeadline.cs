using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can have a deadline.
    /// </summary>
    public interface IDeadline : INotifyPropertyChanged
    {
        DateTime? Deadline { get; set; }
    }
}