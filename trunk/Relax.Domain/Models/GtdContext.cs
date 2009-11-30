using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IGtdContext))]
    public class GtdContext : IGtdContext
    {
        private static int _nextId = 1;
        private DateTime _created;
        private string _description;
        private string _title;

        public GtdContext()
        {
            Created = DateTime.UtcNow;
            Id = _nextId++;
        }

        #region IGtdContext Members

        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyChanged.Raise(x => Description);
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

        public override string ToString()
        {
            return string.Concat("@", Title);
        }
    }
}