using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ProcessActivity
    {
        private readonly AutomationElement _element;

        public ProcessActivity(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public ActionList UnprocessedActionList
        {
            get { return new ActionList(_element.FindChildById("UnprocessedActions")); }
        }

        public EditBox CurrentActionTitle
        {
            get { return new EditBox(_element.FindChildById("CurrentActionTitle")); }
        }
    }
}