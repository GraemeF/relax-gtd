using System;

namespace Fluid
{
    public class EditBox : Control<EditBox>
    {
        public string Text
        {
            get { return AutomationElement.GetValue(); }
            set { AutomationElement.SetValue(value); }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}