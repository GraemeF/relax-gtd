using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ProcessActivity
    {
        private readonly Container _processActivityContainer;

        public ProcessActivity(Container processActivityContainer)
        {
            _processActivityContainer = processActivityContainer;
        }

        public ActionList UnprocessedActionList
        {
            get
            {
                return new ActionList(ListBox.
                                          In(_processActivityContainer, "ActionsView").
                                          Called("Actions").Single());
            }
        }

        public EditBox CurrentActionTitle
        {
            get
            {
                return EditBox.
                    In(_processActivityContainer, "ProcessAction").
                    Called("Title").Single();
            }
        }

        public Button ApplyButton
        {
            get
            {
                return Button.
                    In(_processActivityContainer, "ProcessAction").
                    Called("Apply").Single();
            }
        }

        public bool IsVisible
        {
            get { return _processActivityContainer.IsVisible; }
        }

        public bool IsEmpty
        {
            get
            {
                return !Container.
                            In(_processActivityContainer).
                            Called("ProcessAction").
                            Any();
            }
        }

        public void MarkAsDone()
        {
            ApplyButton.Click();
        }
    }
}