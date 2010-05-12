using Caliburn.Core.IoC;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionPresenter))]
    public class ActionPresenter : ItemPresenter<IAction>, IActionPresenter
    {
        public ActionPresenter(IAction action) : base(action)
        {
        }
    }
}