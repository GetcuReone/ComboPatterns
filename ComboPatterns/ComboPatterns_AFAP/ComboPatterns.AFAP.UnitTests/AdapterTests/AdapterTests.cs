using ComboPatterns.AFAP.UnitTests.AdapterTests.Entities;
using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.AdapterTests
{
    [TestClass]
    public class AdapterTests: AdapterTestsBase
    {
        [TestMethod]
        [Description("[adapter] Creation adapter.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterTestCase()
        {
            var result = Adapter.GetAdapter<Adapter>();

            AssertCreateObjectNumber(1);
            AssertAdapter.AssertCounter(Adapter, callGetAdapterCounter: 1);

            AssertAdapter.NullAndType<Adapter>(result);
        }

        [TestMethod]
        [Description("[adapter] Creation adapter same type.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterSameTypeTestCase()
        {
            var result = Adapter.GetAdapter<TestAdapter>();

            AssertCreateObjectNumber(1);
            AssertAdapter.AssertCounter(Adapter, callGetAdapterCounter: 1);

            AssertAdapter.NullAndType<TestAdapter>(result);
            Assert.AreNotEqual(Adapter, result, "must be different adapters");

            AssertAdapter.AssertCounter(result, 0);
        }

        [TestMethod]
        [Description("[adapter] Creation adapter imlement interface.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterInterfaceTestCase()
        {
            var result = Adapter.GetAdapter<InterfaceAdapter>();

            AssertCreateObjectNumber(1);
            AssertAdapter.AssertCounter(Adapter, callGetAdapterCounter: 1);

            AssertAdapter.NullAndType<InterfaceAdapter>(result);
        }
    }
}
