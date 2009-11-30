using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Presenters.Interfaces
{
    public interface IGtdContextPresenter : IPresenter
    {
        IGtdContext Context { get; }
    }
}