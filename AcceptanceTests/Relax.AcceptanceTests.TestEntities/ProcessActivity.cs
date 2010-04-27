using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ProcessActivity : ActivityTab
    {
        public ProcessActivity(Container activityContainer)
            : base(activityContainer)
        {
        }

        public ActionList UnprocessedActionList
        {
            get
            {
                return new ActionList(ListBox.
                                          In(ActivityContainer, "ActionsView").
                                          Called("Actions").Single());
            }
        }

        public EditBox CurrentActionTitle
        {
            get
            {
                return EditBox.
                    In(ActivityContainer, "ProcessAction").
                    Called("Title").Single();
            }
        }

        public Button ApplyButton
        {
            get
            {
                return Button.
                    In(ActivityContainer, "ProcessAction").
                    Called("Apply").Single();
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !Container.
                            In(ActivityContainer).
                            Called("ProcessAction").
                            Any();
            }
        }

        public ProcessDoLaterTab InDoLaterTab
        {
            get
            {
                TabItem tabItem = TabItem.
                    In(ActivityContainer, "ProcessAction", "ProcessCommands").
                    WithHeading("Later").
                    Single();
                tabItem.Activate();

                return new ProcessDoLaterTab(tabItem);
            }
        }

        public void MarkAsDone()
        {
            ApplyButton.Click();
        }

        public void ChooseTab(string tab)
        {
            TabItem.
                In(ActivityContainer, "ProcessAction", "ProcessCommands").
                WithHeading(tab).
                Single().
                Activate();
        }
    }
}