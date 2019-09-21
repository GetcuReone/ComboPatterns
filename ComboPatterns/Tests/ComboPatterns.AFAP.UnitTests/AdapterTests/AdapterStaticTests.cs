using ComboPatterns.AFAP.UnitTests.AdapterTests.Entities;
using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.AdapterTests
{
    [TestClass]
    public sealed class AdapterStaticTests: AdapterTests
    {
        [TestMethod]
        [Description("[adapter][static] Creation adapter other factory.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterStaticOtherFactoryTestCase()
        {
            var factory = new TestInterfaceFactory();
            var result = AdapterBase.GetAdapterStatic<Adapter>(factory);

            AssertCreateObjectNumber(0);
            AssertAdapter.AssertCounter(Adapter, callGetAdapterCounter: 0);
            Assert.AreEqual(1, factory.CallCreateObjectCounter, "method CreateObject must call");

            AssertAdapter.NullAndType<Adapter>(result);
        }
    }
}
