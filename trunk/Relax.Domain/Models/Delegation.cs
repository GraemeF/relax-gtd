using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (IDelegation))]
    public class Delegation : IDelegation
    {
        private DateTime _delegationDate;

        private string _owner;

        #region IDelegation Members

        [DataMember]
        public DateTime DelegationDate
        {
            get { return _delegationDate; }
            set
            {
                if (value > DateTime.UtcNow)
                    throw new ArgumentOutOfRangeException("value", value,
                                                          "The date and time of delegation must not be in the future.");

                if (value != _delegationDate)
                {
                    _delegationDate = value;
                    PropertyChanged.Raise(x => DelegationDate);
                }
            }
        }

        [DataMember]
        public string Owner
        {
            get { return _owner; }
            set
            {
                if (value != _owner)
                {
                    _owner = value;
                    PropertyChanged.Raise(x => Owner);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}