using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Workspace
    {
        private readonly Container _container;

        public Workspace(Container container)
        {
            _container = container;
        }

        public Button CollectButton
        {
            get { return Button.In(_container).Called("CollectActivityButton").Single(); }
        }

        public CollectActivity CollectActivity
        {
            get { return new CollectActivity(Container.In(_container).Called("Collect").Single()); }
        }

        public ProcessActivity ProcessActivity
        {
            get { return new ProcessActivity(Container.In(_container).Called("Process").Single()); }
        }

        public Button ProcessButton
        {
            get { return Button.In(_container).Called("ProcessActivityButton").Single(); }
        }
    }
}