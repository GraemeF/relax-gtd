using System;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (IReview))]
    public class Review : Model, IReview
    {
        private HorizonOfFocus _horizonOfFocus;
        private DateTime? _lastReviewed;
        private TimeSpan _reviewFrequency;

        #region IReview Members

        [DataMember]
        public DateTime? LastReviewed
        {
            get { return _lastReviewed; }
            set
            {
                if (value != _lastReviewed)
                {
                    _lastReviewed = value;
                    RaisePropertyChanged("LastReviewed");
                }
            }
        }

        [DataMember]
        public TimeSpan ReviewFrequency
        {
            get { return _reviewFrequency; }
            set
            {
                if (value != _reviewFrequency)
                {
                    _reviewFrequency = value;
                    RaisePropertyChanged("ReviewFrequency");
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
                    RaisePropertyChanged("HorizonOfFocus");
                }
            }
        }

        #endregion
    }
}