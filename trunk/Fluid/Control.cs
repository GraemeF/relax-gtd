using System.Windows.Automation;

namespace Fluid
{
    public abstract class Control<TControl>
        where TControl : Control<TControl>, new()
    {
        public AutomationElement AutomationElement { get; set; }

        public static ControlBuilder<TControl> In(IContainer container, params string[] path)
        {
            AutomationElement element = container.AutomationElement;
            foreach (string automationId in path)
                element =
                    element.FindChildByCondition(new PropertyCondition(AutomationElement.AutomationIdProperty,
                                                                       automationId));

            return new ControlBuilder<TControl> {Parent = element};
        }
    }
}