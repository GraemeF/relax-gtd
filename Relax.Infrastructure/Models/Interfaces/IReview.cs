using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that should be regularly reviewed.
    /// </summary>
    public interface IReview : INotifyPropertyChanged
    {
        DateTime? LastReviewed { get; set; }

        TimeSpan ReviewPeriod { get; set; }

        HorizonOfFocus HorizonOfFocus { get; set; }
    }
}