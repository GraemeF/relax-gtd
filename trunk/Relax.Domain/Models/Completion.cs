using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract]
    [PerRequest(typeof (ICompletion))]
    public class Completion : ICompletion
    {
        public Completion()
        {
            CompletedDate = DateTime.Now;
        }

        #region ICompletion Members

        [DataMember]
        public DateTime CompletedDate { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}