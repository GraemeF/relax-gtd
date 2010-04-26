using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class Context
    {
        private readonly Container _container;

        public Context(Container container)
        {
            _container = container;
        }

        public string Title
        {
            get { return EditBox.In(_container).Called("Title").First().Text; }
        }
    }
}