using System.Windows.Automation;

namespace Fluid
{
    public abstract class Control<TBuilder, TControl>
        where TBuilder : ControlBuilder<TBuilder, TControl>, new()
        where TControl : Control<TBuilder, TControl>, new()
    {
        public AutomationElement AutomationElement { get; set; }

        public static TBuilder In(IContainer container, params string[] path)
        {
            AutomationElement element = container.AutomationElement;
            foreach (string automationId in path)
                element =
                    element.FindChildByCondition(new PropertyCondition(AutomationElement.AutomationIdProperty,
                                                                       automationId));

            return new TBuilder {Parent = element};
        }
    }
}