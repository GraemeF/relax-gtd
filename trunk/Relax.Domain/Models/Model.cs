using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.Serialization;

namespace Relax.Domain.Models
{
    /// <summary>
    /// Defines the base class for a model.
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class Model : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyInfo">The property info of the property that has changed.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        protected void RaisePropertyChanged(PropertyInfo propertyInfo)
        {
            CheckPropertyInfo(propertyInfo);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyInfo.Name));
        }

        protected void RaisePropertyChanged(string name)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(name));
        }

        [Conditional("DEBUG")]
        private void CheckPropertyInfo(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.DeclaringType.IsInstanceOfType(this))
                throw new ArgumentException("The passed propertyInfo is from the wrong DeclaringType.", "propertyInfo");
        }
    }
}