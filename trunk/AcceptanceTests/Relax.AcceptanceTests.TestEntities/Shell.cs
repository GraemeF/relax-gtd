using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Shell
    {
        private readonly Window _window;

        public Shell(Window window)
        {
            _window = window;
        }

        public Workspace Workspace
        {
            get { return new Workspace(Container.In(_window).Called("Workspace").First()); }
        }
    }
}