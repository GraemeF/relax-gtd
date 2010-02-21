using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace Fluid
{
    public class ControlBuilder<TControl> : IEnumerable<TControl>
        where TControl : IControl, new()
    {
        private readonly List<Func<AutomationElement, bool>> _conditions = new List<Func<AutomationElement, bool>>();
        public AutomationElement Parent { get; set; }

        #region IEnumerable<TControl> Members

        public IEnumerator<TControl> GetEnumerator()
        {
            if (Parent == null)
                throw new UIElementNotFoundException("There is no parent element to look in.");

            return Parent.
                FindChildren(MeetingConditions).
                Select(element => new TControl {AutomationElement = element}).
                GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public ControlBuilder<TControl> Matching(Func<AutomationElement, bool> condition)
        {
            _conditions.Add(condition);
            return this;
        }

        private bool MeetingConditions(AutomationElement automationElement)
        {
            return _conditions.All(condition => condition(automationElement));
        }

        public ControlBuilder<TControl> Called(string id)
        {
            return Matching(x => x.Current.AutomationId == id);
        }

        public ControlBuilder<TControl> In(Container container)
        {
            Parent = container.AutomationElement;
            return this;
        }
    }
}