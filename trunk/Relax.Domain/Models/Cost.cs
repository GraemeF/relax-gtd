using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (ICost))]
    public class Cost : ICost
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
                    PropertyChanged.Raise(x => MentalEnergyRequired);
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
                    PropertyChanged.Raise(x => TimeRequired);
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
                    PropertyChanged.Raise(x => PhysicalEnergyRequired);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}