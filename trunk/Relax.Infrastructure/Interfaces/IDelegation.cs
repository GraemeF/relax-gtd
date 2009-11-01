using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Interfaces
{
    /// <summary>
    /// Something that can be delegated to someone else.
    /// </summary>
    public interface IDelegation : INotifyPropertyChanged
    {
        string Owner { get; set; }

        DateTime DelegationDate { get; set; }
    }
}