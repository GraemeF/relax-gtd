using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ActionList
    {
        private readonly AutomationElement _element;

        public ActionList(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public IEnumerable<string> Actions
        {
            get
            {
                return _element.FindChildByControlType(ControlType.List).FindChildren(
                    x => x.Current.ControlType == ControlType.ListItem).Select(
                    x => x.FindChildById("Action").FindChildById("Title").GetValue());
            }
        }
    }
}