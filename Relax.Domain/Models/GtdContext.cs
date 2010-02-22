using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IGtdContext))]
    public class GtdContext : Item, IGtdContext
    {
        private string _description;

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
                    NotifyPropertyChanged(x => Description);
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return string.Concat("@", Title);
        }
    }
}