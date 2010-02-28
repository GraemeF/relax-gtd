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
                return
                    new ActionList(ListBox.In(_processActivityContainer).Called("UnprocessedActions").Single());
            }
        }

        public EditBox CurrentActionTitle
        {
            get { return EditBox.In(_processActivityContainer).Called("CurrentActionTitle").Single(); }
        }
    }
}