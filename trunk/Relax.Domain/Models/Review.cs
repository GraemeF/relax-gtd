using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (IReview))]
    public class Review : IReview
    {
        private HorizonOfFocus _horizonOfFocus;
        private DateTime? _lastReviewed;
        private TimeSpan _reviewPeriod;

        #region IReview Members

        [DataMember]
        public DateTime? LastReviewed
        {
            get { return _lastReviewed; }
            set
            {
                if (value > DateTime.UtcNow)
                    throw new ArgumentOutOfRangeException("value", value, "The date and time of the last review must not be in the future.");

                if (value != _lastReviewed)
                {
                    _lastReviewed = value;
                    PropertyChanged.Raise(x => LastReviewed);
                }
            }
        }

        [DataMember]
        public TimeSpan ReviewPeriod
        {
            get { return _reviewPeriod; }
            set
            {
                if (value != _reviewPeriod)
                {
                    _reviewPeriod = value;
                    PropertyChanged.Raise(x => ReviewPeriod);
                }
            }
        }

        [DataMember]
        public HorizonOfFocus HorizonOfFocus
        {
            get { return _horizonOfFocus; }
            set
            {
                if (value != _horizonOfFocus)
                {
                    _horizonOfFocus = value;
                    PropertyChanged.Raise(x => HorizonOfFocus);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}