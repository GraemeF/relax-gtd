using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IActionDetailsPresenter))]
    public class ActionDetailsPresenter : Screen, IActionDetailsPresenter
    {
    }
}