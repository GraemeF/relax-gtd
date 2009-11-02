using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    internal class Deferral : Model, IDeferral
    {
        private DateTime _deferUntil;

        #region IDeferral Members

        [DataMember]
        public DateTime DeferUntil
        {
            get { return _deferUntil; }
            set
            {
                if (value != _deferUntil)
                {
                    _deferUntil = value;
                    RaisePropertyChanged("DeferUntil");
                }
            }
        }

        #endregion
    }
}