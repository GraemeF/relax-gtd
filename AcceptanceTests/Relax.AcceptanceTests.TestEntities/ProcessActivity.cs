using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ProcessActivity
    {
        private readonly Container _container;

        public ProcessActivity(Container container)
        {
            _container = container;
        }

        public ActionList UnprocessedActionList
        {
            get
            {
                return
                    new ActionList(ListBox.In(_container).Called("UnprocessedActions").First());
            }
        }

        public EditBox CurrentActionTitle
        {
            get { return EditBox.In(_container).Called("CurrentActionTitle").First(); }
        }
    }
}