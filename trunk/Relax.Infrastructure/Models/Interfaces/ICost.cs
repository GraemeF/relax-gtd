using System;
using System.ComponentModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    public interface ICost : INotifyPropertyChanged
    {
        TimeSpan? TimeRequired { get; set; }
        EnergyLevel? PhysicalEnergyRequired { get; set; }
        EnergyLevel? MentalEnergyRequired { get; set; }
    }
}