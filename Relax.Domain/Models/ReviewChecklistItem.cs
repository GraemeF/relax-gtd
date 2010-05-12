using System.Runtime.Serialization;
using Caliburn.Core.IoC;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(IsReference = true)]
    [PerRequest(typeof (IReviewChecklistItem))]
    public class ReviewChecklistItem : Item, IReviewChecklistItem
    {
        private IReview _review;

        #region IReviewChecklistItem Members

        [DataMember(EmitDefaultValue = false)]
        public IReview Review
        {
            get { return _review; }
            set
            {
                if (_review != value)
                {
                    _review = value;
                    NotifyPropertyChanged(x => Review);
                }
            }
        }

        #endregion
    }
}