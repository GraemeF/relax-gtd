using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IReviewChecklistItem))]
    public class ReviewChecklistItem : IReviewChecklistItem
    {
        private static int _nextId;
        private DateTime _created;
        private HorizonOfFocus _horizonOfFocus;
        private DateTime? _lastReviewed;
        private TimeSpan _reviewFrequency;
        private string _title;

        public ReviewChecklistItem()
        {
            Created = DateTime.UtcNow;
            Id = _nextId++;
        }

        #region IReviewChecklistItem Members

        [DataMember]
        public DateTime? LastReviewed
        {
            get { return _lastReviewed; }
            set
            {
                if (_lastReviewed != value)
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
                if (_reviewFrequency != value)
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
                if (_horizonOfFocus != value)
                {
                    _horizonOfFocus = value;
                    PropertyChanged.Raise(x => HorizonOfFocus);
                }
            }
        }

        [DataMember]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChanged.Raise(x => Title);
                }
            }
        }

        [DataMember]
        public DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    PropertyChanged.Raise(x => Created);
                }
            }
        }

        public int Id { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}