using System.Collections.Generic;
using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ActionList
    {
        private readonly ListBox _listBox;

        public ActionList(ListBox listBox)
        {
            _listBox = listBox;
        }

        public IEnumerable<string> Actions
        {
            get
            {
                return
                    _listBox.Items.Select(
                        x => new Action(Container.In(x).Called("Action").First()).Title);
            }
        }
    }
}