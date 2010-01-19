using System;
using System.Windows.Automation;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Button
    {
        private readonly AutomationElement _element;

        public Button(AutomationElement element)
        {
            if (element == null) throw new ArgumentNullException("element");

            _element = element;
        }

        public bool IsEnabled
        {
            get { return _element.Current.IsEnabled; }
        }

        public void Click()
        {
            _element.GetInvokePattern().Invoke();
        }
    }
}