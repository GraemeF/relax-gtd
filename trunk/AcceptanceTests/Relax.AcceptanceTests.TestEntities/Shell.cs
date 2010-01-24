using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Shell
    {
        private readonly AutomationElement _element;

        public Shell(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public Workspace Workspace
        {
            get { return new Workspace(_element.FindChildById("Workspace")); }
        }
    }

    public class Workspace
    {
        private readonly AutomationElement _element;

        public Workspace(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public Button CollectButton
        {
            get { return new Button(_element.FindChildById("CollectActivityButton")); }
        }

        public CollectActivity CollectActivity
        {
            get { return new CollectActivity(_element.FindChildById("Collect")); }
        }

        public Button ProcessButton
        {
            get { return new Button(_element.FindChildById("ProcessActivityButton")); }
        }
    }
}