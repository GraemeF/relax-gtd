using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
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