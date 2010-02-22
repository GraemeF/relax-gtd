using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    public abstract class Item : IItem
    {
        private string _title;

        protected Item()
        {
            Created = DateTime.UtcNow;
        }

        #region IItem Members

        [DataMember]
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (_title != value)
                {
                    _title = value;
                    PropertyChanged.Raise(x => Title);
                }
            }
        }

        [DataMember]
        public DateTime Created { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(Expression<Func<object, object>> property)
        {
            PropertyChanged.Raise(property);
        }
    }
}