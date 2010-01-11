using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Shell
    {
        private readonly AutomationElement _shell;

        public Shell(AutomationElement shell)
        {
            _shell = shell;
        }
    }
}