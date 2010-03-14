using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IGtdContextPresenter))]
    public class ContextPresenter : ItemPresenter<IGtdContext>, IGtdContextPresenter
    {
        public ContextPresenter(IGtdContext context) : base(context)
        {
        }
    }
}