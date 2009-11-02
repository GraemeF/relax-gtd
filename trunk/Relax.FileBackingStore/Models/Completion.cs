using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    public class Completion : Model, ICompletion
    {
        private DateTime _CompletedDate;

        public Completion()
        {
            CompletedDate = DateTime.Now;
        }

        #region ICompletion Members

        [DataMember]
        public DateTime CompletedDate
        {
            get { return _CompletedDate; }
            set
            {
                if (value != _CompletedDate)
                {
                    _CompletedDate = value;
                    RaisePropertyChanged("CompletedDate");
                }
            }
        }

        #endregion
    }
}