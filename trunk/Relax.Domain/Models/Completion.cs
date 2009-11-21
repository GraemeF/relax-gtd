using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (ICompletion))]
    public class Completion : ICompletion
    {
        private DateTime _completedDate;

        public Completion()
        {
            CompletedDate = DateTime.Now;
        }

        #region ICompletion Members

        [DataMember]
        public DateTime CompletedDate
        {
            get { return _completedDate; }
            set
            {
                if (value != _completedDate)
                {
                    _completedDate = value;
                    PropertyChanged.Raise(x => CompletedDate);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}