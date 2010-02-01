using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class EditBox
    {
        private readonly AutomationElement _element;

        public EditBox(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            _element = element;
        }

        public string Text
        {
            get { return _element.GetValue(); }
            set { _element.SetValue(value); }
        }
    }
}