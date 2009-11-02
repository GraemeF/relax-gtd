using System;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    [PerRequest(typeof (ICost))]
    public class Cost : Model, ICost
    {
        private EnergyLevel? _mentalEnergyRequired;
        private EnergyLevel? _physicalEnergyRequired;
        private TimeSpan? _timeRequired;

        #region ICost Members

        [DataMember]
        public EnergyLevel? MentalEnergyRequired
        {
            get { return _mentalEnergyRequired; }
            set
            {
                if (value != _mentalEnergyRequired)
                {
                    _mentalEnergyRequired = value;
                    RaisePropertyChanged("MentalEnergyRequired");
                }
            }
        }

        [DataMember]
        public TimeSpan? TimeRequired
        {
            get { return _timeRequired; }
            set
            {
                if (value != _timeRequired)
                {
                    _timeRequired = value;
                    RaisePropertyChanged("TimeRequired");
                }
            }
        }

        [DataMember]
        public EnergyLevel? PhysicalEnergyRequired
        {
            get { return _physicalEnergyRequired; }
            set
            {
                if (value != _physicalEnergyRequired)
                {
                    _physicalEnergyRequired = value;
                    RaisePropertyChanged("PhysicalEnergyRequired");
                }
            }
        }

        #endregion
    }
}