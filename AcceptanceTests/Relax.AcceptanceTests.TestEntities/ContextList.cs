using System.Collections.Generic;
using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ContextList
    {
        private readonly ListBox _listBox;

        public ContextList(ListBox listBox)
        {
            _listBox = listBox;
        }

        public IEnumerable<string> Contexts
        {
            get
            {
                return
                    _listBox.Items.Select(
                        x => new Context(Container.In(x).Called("Context").First()).Title);
            }
        }
    }
}