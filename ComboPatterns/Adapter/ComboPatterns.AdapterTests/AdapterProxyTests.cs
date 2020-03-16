using ComboPatterns.AdapterTests.Env;
using GetcuReone.ComboPatterns.Adapter;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComboPatterns.AdapterTests
{
    [TestClass]
    public sealed class AdapterProxyTests : FactoryTestBase<Factory>
    {
        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter] create proxy")]
        public void CreateProxyTestCase()
        {
            GivenCreateFactory()
                .And("Create adapter", factory => AdapterBase.Create<AdapterProxy>(factory))
                .When("Create proxy", adapter => adapter.CreateProxy())
                .Then("Check result", proxy =>
                {
                    Assert.IsNotNull(proxy, "proxy cannot be null");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter][negative] create adapter without createProxyFunc")]
        public void CreateAdapterWithoutFuncTestCase()
        {
            GivenCreateFactory()
                .When("Create adapter", factory => ExpectedException<Exception>(() => AdapterBase.Create<InvalidAdapterProxy>(factory)))
                .Then("Check result", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.AreEqual("createProxyFunc", ((ArgumentNullException)ex.InnerException).ParamName, "expected another message");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter] create proxy with parameter")]
        public void CreateProxyWithParamTestCase()
        {
            var param = new object();

            GivenCreateFactory()
                .And("Create adapter", factory => AdapterBase.Create<AdapterProxyParameter>(factory))
                .When("Create proxy", adapter => adapter.CreateProxy(param))
                .Then("Check result", proxy =>
                {
                    Assert.IsNotNull(proxy, "proxy cannot be null");
                    Assert.AreEqual(param, proxy.Param, "expected another value parameter");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter][negative] create adapter without createProxyFunc")]
        public void CreateAdapterParamWithoutFuncTestCase()
        {
            GivenCreateFactory()
                .When("Create adapter", factory => ExpectedException<Exception>(() => AdapterBase.Create<InvalidAdapterProxyParameter>(factory)))
                .Then("Check result", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.AreEqual("createProxyFuncWithParam", ((ArgumentNullException)ex.InnerException).ParamName, "expected another message");
                });
        }
    }
}
