using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
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
                if (_title != value)
                {
                    _title = value;
                    PropertyChanged.Raise(x => Title);
                }
            }
        }

        [DataMember]
        public DateTime Created { get; private set; }

        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(Expression<Func<object, object>> property)
        {
            PropertyChanged.Raise(property);
        }

 
        #endregion
    }
}