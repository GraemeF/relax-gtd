using Moq;

namespace Relax.TestDataBuilders
{
    public abstract class BuilderBase<T> where T : class
    {
        public T Build()
        {
            return Mock().Object;
        }

        public Mock<T> Mock()
        {
            var mock = new Mock<T>();
            SetupMock(mock);
            return mock;
        }

        protected abstract void SetupMock(Mock<T> mock);
    }
}