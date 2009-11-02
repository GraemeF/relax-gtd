using System;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    [PerRequest(typeof (ICompletion))]
    public class Completion : Model, ICompletion
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
                    RaisePropertyChanged("CompletedDate");
                }
            }
        }

        #endregion
    }
}