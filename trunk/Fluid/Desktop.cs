using System.Windows.Automation;

namespace Fluid
{
    public class Desktop
    {
        public static WindowBuilder Window
        {
            get { return new WindowBuilder {Parent = AutomationElement.RootElement}; }
        }
    }
}