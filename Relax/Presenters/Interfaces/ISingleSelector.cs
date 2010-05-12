using Caliburn.PresentationFramework.Screens;

namespace Relax.Presenters.Interfaces
{
    public interface ISingleSelector<TItem> : IScreenConductor
    {
        TItem SelectedItem { get; set; }
    }
}