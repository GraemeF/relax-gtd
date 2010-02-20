using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class CollectActivity
    {
        private readonly Container _container;

        public CollectActivity(Container container)
        {
            _container = container;
        }

        public ActionList ActionList
        {
            get
            {
                return
                    new ActionList(ListBox.In(_container, "ActionsView").Called("Actions").First());
            }
        }
    }
}