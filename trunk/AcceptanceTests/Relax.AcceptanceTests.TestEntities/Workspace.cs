using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
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

        public ProcessActivity ProcessActivity
        {
            get { return new ProcessActivity(_element.FindChildById("Process")); }
        }

        public Button ProcessButton
        {
            get { return new Button(_element.FindChildById("ProcessActivityButton")); }
        }
    }
}