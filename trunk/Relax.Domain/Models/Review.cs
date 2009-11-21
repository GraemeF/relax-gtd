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
                    PropertyChanged.Raise(x => LastReviewed);
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
                    PropertyChanged.Raise(x => ReviewFrequency);
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