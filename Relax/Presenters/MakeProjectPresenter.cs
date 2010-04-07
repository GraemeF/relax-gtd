using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class MakeProjectPresenter
    {
        public MakeProjectPresenter(IOptionalProjectSelector projectSelector)
        {
            Projects = projectSelector;
        }

        public IOptionalProjectSelector Projects { get; private set; }
    }
}