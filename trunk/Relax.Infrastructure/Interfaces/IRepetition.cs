using System;

namespace Relax.Infrastructure.Interfaces
{
    public interface IRepetition
    {
        TimeSpan? RepeatLength { get; set; }
        RepeatType? RepeatType { get; set; }
    }
}