using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract(IsReference = true)]
    public class ReviewChecklistItem : Model, IReviewChecklistItem
    {
        private static int _NextId;
        private DateTime _Created;
        private HorizonOfFocus _HorizonOfFocus;
        private DateTime? _LastReviewed;
        private TimeSpan _ReviewFrequency;
        private string _Title;

        public ReviewChecklistItem()
        {
            Created = DateTime.UtcNow;
            Id = _NextId++;
        }

        #region IReviewChecklistItem Members

        [DataMember]
        public DateTime? LastReviewed
        {
            get { return _LastReviewed; }
            set
            {
                if (_LastReviewed != value)
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
                if (_ReviewFrequency != value)
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
                if (_HorizonOfFocus != value)
                {
                    _HorizonOfFocus = value;
                    RaisePropertyChanged("HorizonOfFocus");
                }
            }
        }

        [DataMember]
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        [DataMember]
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                if (_Created != value)
                {
                    _Created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }

        public int Id { get; private set; }

        #endregion
    }
}