using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be completed.
    /// </summary>
    public interface ICompletion : INotifyPropertyChanged
    {
        DateTime CompletedDate { get; }
    }
}