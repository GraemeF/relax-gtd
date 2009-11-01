using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Interfaces
{
    /// <summary>
    /// Something that can have a deadline.
    /// </summary>
    public interface IDeadline : INotifyPropertyChanged
    {
        DateTime DeadlineDate { get; set; }
    }
}