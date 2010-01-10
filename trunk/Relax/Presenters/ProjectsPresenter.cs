using System.Collections.ObjectModel;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;
using Relax.Tests.Presenters;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProjectsPresenter))]
    public class ProjectsPresenter : MultiPresenterManager, IProjectsPresenter
    {
        private readonly IWorkspace _workspace;

        public ProjectsPresenter(IWorkspace workspace)
        {
            _workspace = workspace;
        }

        public ObservableCollection<IProjectPresenter> TopLevelProjects { get; private set; }
    }
}