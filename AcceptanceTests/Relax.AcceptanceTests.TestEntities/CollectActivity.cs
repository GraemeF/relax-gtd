using System.Linq;
using Fluid;

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
    }
}