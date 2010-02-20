using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace Fluid
{
    public class ControlBuilder<TBuilder, TControl> : IEnumerable<TControl>
        where TBuilder : ControlBuilder<TBuilder, TControl>, new()
        where TControl : Control<TBuilder, TControl>, new()
    {
        private string _id;
        public AutomationElement Parent { get; set; }

        #region IEnumerable<TControl> Members

        public IEnumerator<TControl> GetEnumerator()
        {
            if (Parent == null)
                throw new UIElementNotFoundException("There is no parent element to look in.");

            return Parent.
                FindChildren(MeetingCriteria).
                Select(element => new TControl {AutomationElement = element}).
                GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        private bool MeetingCriteria(AutomationElement automationElement)
        {
            return _id == null || automationElement.Current.AutomationId == _id;
        }

        public TBuilder Called(string id)
        {
            return new TBuilder {Parent = Parent, _id = id};
        }

        public TBuilder In(Container container)
        {
            return new TBuilder {Parent = container.AutomationElement, _id = _id};
        }
    }
}