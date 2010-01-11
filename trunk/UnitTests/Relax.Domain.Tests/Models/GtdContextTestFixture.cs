using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class GtdContextTestFixture
    {
        [VerifyContract]
        public readonly IContract Description = new AccessorContract<GtdContext, string>
                                                    {
                                                        PropertyName = "Description",
                                                        AcceptNullValue = true,
                                                        ValidValues = {"Some description", new string('x', 50)}
                                                    };

        [Test]
        public void ToString__ReturnsTitleWithAt()
        {
            var test = new GtdContext {Title = "Hello"};

            Assert.AreEqual("@Hello", test.ToString());
        }
    }
}