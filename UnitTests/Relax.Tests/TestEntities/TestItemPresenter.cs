using Relax.Presenters;

namespace Relax.Tests.TestEntities
{
    internal class TestItemPresenter : ItemPresenter<ITestItem>, ITestItemPresenter
    {
        public TestItemPresenter(ITestItem item) : base(item)
        {
        }
    }
}