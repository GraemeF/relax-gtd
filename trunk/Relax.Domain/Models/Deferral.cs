using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (IDeferral))]
    public class Deferral : IDeferral
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
                    PropertyChanged.Raise(x => DeferUntil);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}