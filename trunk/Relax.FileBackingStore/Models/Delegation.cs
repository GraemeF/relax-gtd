using System;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    [PerRequest(typeof (IDelegation))]
    internal class Delegation : Model, IDelegation
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
                if (value != _delegationDate)
                {
                    _delegationDate = value;
                    RaisePropertyChanged("DelegationDate");
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
                    RaisePropertyChanged("Owner");
                }
            }
        }

        #endregion
    }
}