using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class MakeProjectPresenter
    {
        public MakeProjectPresenter(IProjectsPresenter projectsPresenter)
        {
            Projects = projectsPresenter;
        }

        public IProjectsPresenter Projects { get; private set; }
    }
}