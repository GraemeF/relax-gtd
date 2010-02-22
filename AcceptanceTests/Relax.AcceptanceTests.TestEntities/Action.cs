using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Action
    {
        private readonly Container _container;

        public Action(Container container)
        {
            _container = container;
        }

        public string Title
        {
            get { return EditBox.In(_container).Called("Title").First().Text; }
        }
    }
}