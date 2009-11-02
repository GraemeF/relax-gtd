using System;
using System.Runtime.Serialization;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract(IsReference = true)]
    public class Context : Model, IContext
    {
        private static int _NextId = 1;
        private DateTime _Created;
        private string _Description;
        private string _Title;

        public Context()
        {
            Created = DateTime.UtcNow;
            Id = _NextId++;
        }

        #region IContext Members

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    RaisePropertyChanged("Description");
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

        public override string ToString()
        {
            return string.Concat("@", Title);
        }
    }
}