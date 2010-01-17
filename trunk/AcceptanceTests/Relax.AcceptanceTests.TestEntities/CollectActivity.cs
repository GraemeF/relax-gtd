using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class CollectActivity
    {
        private readonly AutomationElement _element;

        public CollectActivity(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public ActionList ActionList
        {
            get { return new ActionList(_element.FindChildById("Actions")); }
        }
    }
}