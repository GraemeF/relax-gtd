using System;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IContext))]
    public class Context : Model, IContext
    {
        private static int _nextId = 1;
        private DateTime _created;
        private string _description;
        private string _title;

        public Context()
        {
            Created = DateTime.UtcNow;
            Id = _nextId++;
        }

        #region IContext Members

        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("Description");
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
                    RaisePropertyChanged("Title");
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
                    RaisePropertyChanged("Created");
                }
            }
        }

        public int Id { get; private set; }

        #endregion

        public override string ToString()
        {
            return string.Concat("@", Title);
        }
    }
}