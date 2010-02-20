namespace Fluid
{
    public class Button : Control<ButtonBuilder, Button>
    {
        public bool IsEnabled
        {
            get { return AutomationElement.Current.IsEnabled; }
        }

        public string Text
        {
            get { return AutomationElement.Current.Name; }
        }

        public void Click()
        {
            AutomationElement.GetInvokePattern().Invoke();
        }
    }
}