using ComboPatterns.AFAP.UnitTests.AdapterTests.Entities;
using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComboPatterns.AFAP.UnitTests.AdapterTests
{
    [TestClass]
    public sealed class AdapterProxyTests : AdapterTestsBase
    {
        [TestMethod]
        [Description("[adapter][proxy] Creation adapter with proxy.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterProxyTestCase()
        {
            var adapter = Adapter.GetAdapter<TestAdapterProxy>();
            var result = adapter.CreateProxy();

            AssertCreateObjectNumber(2);
            AssertAdapter.AssertCounter(Adapter, callGetAdapterCounter: 1);

            AssertAdapter.NullAndType<TestAdapterProxy>(adapter);
            TestHelper.AssertCounter(1, adapter.CallCreateProxyCounter, nameof(TestAdapterProxy.CreateProxy));

            Assert.IsNotNull(result, "proxy should not be null");
            Assert.IsTrue(result is object, "proxy must type TestClass");
        }

        [TestMethod]
        [Description("[negative][adapter][proxy] Creation invalid adapter with proxy.")]
        [Timeout(Timeuot.Millisecond.Hundred)]
        public void GetInvalidAdapterProxyTestCase()
        {
            var expectedException = new ArgumentNullException("createProxyFunc", $"Func creation proxy must be not null");

            var exception = TestHelper.ExpectedException<ArgumentNullException>(
                () => Adapter.GetAdapter<InvalidAdapterProxy>());

            Assert.AreEqual(expectedException.Message, exception.Message, "received an error with another message");
        }

        [TestMethod]
        [Description("[adapter][proxy] Creation adapter with proxy with param.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterProxyParamTestCase()
        {
            string param = "Dugu";

            var adapter = Adapter.GetAdapter<TestAdapterProxy<string>>();
            var result = adapter.CreateProxy(param);

            AssertCreateObjectNumber(2);
            AssertAdapter.AssertCounter(Adapter, callGetAdapterCounter: 1);

            AssertAdapter.NullAndType<TestAdapterProxy<string>>(adapter);
            TestHelper.AssertCounter(1, adapter.CallCreateProxyCounter, nameof(TestAdapterProxy.CreateProxy));

            Assert.IsNotNull(result, "proxy should not be null");
            Assert.IsTrue(result is object, "proxy must type TestClass");
            Assert.AreEqual(param, result.Obj, "must match proxy param");
        }

        [TestMethod]
        [Description("[negative][adapter][proxy] Creation invalid adapter with proxy with param.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetInvalidAdapterProxyParamTestCase()
        {
            var expectedException = new ArgumentNullException("createProxyFuncWithParam", $"Func creation proxy with param must be not null");

            var exception = TestHelper.ExpectedException<ArgumentNullException>(
                () => Adapter.GetAdapter<InvalidAdapterProxy<int>>());

            Assert.AreEqual(expectedException.Message, exception.Message, "received an error with another message");
        }
    }
}
