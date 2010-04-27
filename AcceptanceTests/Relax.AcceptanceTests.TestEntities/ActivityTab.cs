using Fluid;

namespace Relax.AcceptanceTests.TestEntities
{
    public class ActivityTab
    {
        protected readonly Container ActivityContainer;

        protected ActivityTab(Container activityContainer)
        {
            ActivityContainer = activityContainer;
        }

        public bool IsVisible
        {
            get { return ActivityContainer.IsVisible; }
        }
    }
}