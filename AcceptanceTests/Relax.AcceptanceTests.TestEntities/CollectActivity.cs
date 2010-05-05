using System;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Fluid;
using ListBox = Fluid.ListBox;

namespace Relax.AcceptanceTests.TestEntities
{
    public class CollectActivity : ActivityTab
    {
        public CollectActivity(Container container)
            : base(container)
        {
        }

        public ActionList ActionList
        {
            get
            {
                return
                    new ActionList(GetActionsListBox());
            }
        }

        private ListBox GetActionsListBox()
        {
            return ListBox.
                In(ActivityContainer, "ActionsView").
                Called("Actions").
                First();
        }

        public void SelectInboxActionAt(int index)
        {
            GetActionsListBox().Items.ElementAt(index).Select();
        }

        public void RenameInboxAction(int index, string title)
        {
            ClickOnInboxActionAt(index);
            Keyboard.Type(Key.F2);
            Keyboard.Type(title);
        }

        private void ClickOnInboxActionAt(int index)
        {
            GetActionsListBox().Items.ElementAt(index);
            throw new NotImplementedException();
        }
    }
}