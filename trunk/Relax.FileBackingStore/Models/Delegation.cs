using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    internal class Delegation : Model, IDelegation
    {
        private DateTime _DelegationDate;

        private string _Owner;

        #region IDelegation Members

        [DataMember]
        public DateTime DelegationDate
        {
            get { return _DelegationDate; }
            set
            {
                if (value != _DelegationDate)
                {
                    _DelegationDate = value;
                    RaisePropertyChanged("DelegationDate");
                }
            }
        }

        [DataMember]
        public string Owner
        {
            get { return _Owner; }
            set
            {
                if (value != _Owner)
                {
                    _Owner = value;
                    RaisePropertyChanged("Owner");
                }
            }
        }

        #endregion
    }
}