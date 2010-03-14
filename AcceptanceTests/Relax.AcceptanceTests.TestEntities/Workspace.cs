using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Workspace
    {
        private readonly Container _workspaceContainer;

        public Workspace(Container workspaceContainer)
        {
            _workspaceContainer = workspaceContainer;
        }

        public Button CollectButton
        {
            get { return Button.In(_workspaceContainer).Called("CollectActivityButton").Single(); }
        }

        public CollectActivity CollectActivity
        {
            get { return new CollectActivity(Container.In(_workspaceContainer).Called("Collect").Single()); }
        }

        public ProcessActivity ProcessActivity
        {
            get { return new ProcessActivity(Container.In(_workspaceContainer).Called("Process").Single()); }
        }

        public Button ProcessButton
        {
            get { return Button.In(_workspaceContainer).Called("ProcessActivityButton").Single(); }
        }
    }
}