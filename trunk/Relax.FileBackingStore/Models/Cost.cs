using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    public class Cost : Model, ICost
    {
        private EnergyLevel? _MentalEnergyRequired;
        private EnergyLevel? _PhysicalEnergyRequired;
        private TimeSpan? _TimeRequired;

        #region ICost Members

        [DataMember]
        public EnergyLevel? MentalEnergyRequired
        {
            get { return _MentalEnergyRequired; }
            set
            {
                if (value != _MentalEnergyRequired)
                {
                    _MentalEnergyRequired = value;
                    RaisePropertyChanged("MentalEnergyRequired");
                }
            }
        }

        [DataMember]
        public TimeSpan? TimeRequired
        {
            get { return _TimeRequired; }
            set
            {
                if (value != _TimeRequired)
                {
                    _TimeRequired = value;
                    RaisePropertyChanged("TimeRequired");
                }
            }
        }

        [DataMember]
        public EnergyLevel? PhysicalEnergyRequired
        {
            get { return _PhysicalEnergyRequired; }
            set
            {
                if (value != _PhysicalEnergyRequired)
                {
                    _PhysicalEnergyRequired = value;
                    RaisePropertyChanged("PhysicalEnergyRequired");
                }
            }
        }

        #endregion
    }
}