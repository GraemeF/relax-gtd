﻿using System;

namespace Relax.Infrastructure.Models.Interfaces
{
    public interface IRepetition
    {
        TimeSpan? RepeatLength { get; set; }
        RepeatType? RepeatType { get; set; }
    }
}