using Relax.Presenters;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class FactoryCachingDictionaryTestFixture
    {
        [Fact]
        public void GetOrCreate_GivenParameter_ReturnsItemCreatedWithParameter()
        {
            var test = new FactoryCachingDictionary<int, string>(x => x.ToString());
            Assert.Equal("6", test.GetOrCreate(6));
        }

        [Fact]
        public void GetOrCreate_GivenParameterAgain_ReturnsItemPreviouslyCreatedFromTheParameter()
        {
            int createdItemCount = 0;
            var test = new FactoryCachingDictionary<string, int>(x => ++createdItemCount);
            Assert.Equal(1, test.GetOrCreate("First item"));
            Assert.Equal(2, test.GetOrCreate("Second item"));
            Assert.Equal(1, test.GetOrCreate("First item"));
        }
    }
}