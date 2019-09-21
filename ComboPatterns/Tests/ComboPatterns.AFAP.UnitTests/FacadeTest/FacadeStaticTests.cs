using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.FacadeTest
{
    [TestClass]
    public sealed class FacadeStaticTests : FacadeTestsBase
    {
        [TestMethod]
        [Description("[facade][static] Creation facade other factory")]
        [Timeout(Timeuot.Millisecond.Hundred)]
        public void GetFacadeStaticOtherFactoryTestCase()
        {
            var factory = new TestInterfaceFactory();
            var result = FacadeBase.GetFacadeStatic<Facade>(factory);

            AssertFacadeTestObj(0);
            AssertFacade.AssertCounter(Facade, callGetFacadeCounter: 0);
            Assert.AreEqual(1, factory.CallCreateObjectCounter, "method CreateObject must call");

            AssertFacade.NullAndType<Facade>(result);
        }
    }
}
