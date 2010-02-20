namespace Fluid
{
    public class EditBox : Control<EditBoxBuilder, EditBox>
    {
        public string Text
        {
            get { return AutomationElement.GetValue(); }
            set { AutomationElement.SetValue(value); }
        }
    }
}