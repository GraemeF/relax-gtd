using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Interfaces
{
    public interface ICost : INotifyPropertyChanged
    {
        TimeSpan? TimeRequired { get; set; }
        EnergyLevel? PhysicalEnergyRequired { get; set; }
        EnergyLevel? MentalEnergyRequired { get; set; }
    }
}