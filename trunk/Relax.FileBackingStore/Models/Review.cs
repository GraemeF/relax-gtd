using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract]
    internal class Review : Model, IReview
    {
        private HorizonOfFocus _HorizonOfFocus;
        private DateTime? _LastReviewed;
        private TimeSpan _ReviewFrequency;

        #region IReview Members

        [DataMember]
        public DateTime? LastReviewed
        {
            get { return _LastReviewed; }
            set
            {
                if (value != _LastReviewed)
                {
                    _LastReviewed = value;
                    RaisePropertyChanged("LastReviewed");
                }
            }
        }

        [DataMember]
        public TimeSpan ReviewFrequency
        {
            get { return _ReviewFrequency; }
            set
            {
                if (value != _ReviewFrequency)
                {
                    _ReviewFrequency = value;
                    RaisePropertyChanged("ReviewFrequency");
                }
            }
        }

        [DataMember]
        public HorizonOfFocus HorizonOfFocus
        {
            get { return _HorizonOfFocus; }
            set
            {
                if (value != _HorizonOfFocus)
                {
                    _HorizonOfFocus = value;
                    RaisePropertyChanged("HorizonOfFocus");
                }
            }
        }

        #endregion
    }
}