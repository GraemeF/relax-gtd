using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Interfaces
{
    /// <summary>
    /// Something that should be regularly reviewed.
    /// </summary>
    public interface IReview : INotifyPropertyChanged
    {
        DateTime? LastReviewed { get; set; }

        TimeSpan ReviewFrequency { get; set; }

        HorizonOfFocus HorizonOfFocus { get; set; }
    }
}