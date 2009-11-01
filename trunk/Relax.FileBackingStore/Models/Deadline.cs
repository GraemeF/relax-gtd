using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    internal class Deadline : Model, IDeadline
    {
        private DateTime _deadlineDate;

        #region IDeadline Members

        [DataMember]
        public DateTime DeadlineDate
        {
            get { return _deadlineDate; }
            set
            {
                if (value != _deadlineDate)
                {
                    _deadlineDate = value;
                    RaisePropertyChanged("DeadlineDate");
                }
            }
        }

        #endregion
    }
}