using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IDoNowPresenter))]
    public class DoNowPresenter : Presenter, IDoNowPresenter
    {
    }
}