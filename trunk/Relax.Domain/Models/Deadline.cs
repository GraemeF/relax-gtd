using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (IDeadline))]
    public class Deadline : IDeadline
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
                    PropertyChanged.Raise(x => DeadlineDate);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}