using System;
using System.Linq;
using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ProcessDoLaterTab
    {
        private readonly TabItem _tabItem;

        public ProcessDoLaterTab(TabItem tabItem)
        {
            _tabItem = tabItem;
        }


        public ContextList ContextList
        {
            get
            {
                return new ContextList(ListBox.
                                           In(_tabItem, "ContextsView").
                                           Called("Contexts").Single());
            }
        }

        public void AddContext(string context)
        {
            Button.
                In(_tabItem, "DoLater", "Contexts").
                Called("AddButton").Single().
                Click();
        }
    }
}