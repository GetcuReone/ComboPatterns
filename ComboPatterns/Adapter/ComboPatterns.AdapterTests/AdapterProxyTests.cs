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
        [TestCategory(TC.Unit), TestCategory(TC.Adapter)]
        [Description("Create proxy.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
        [TestCategory(TC.Unit), TestCategory(TC.Adapter), TestCategory(TC.Negative)]
        [Description("Create adapter without createProxyFunc.")]
        [Timeout(Timeouts.MilliSecond.FiveHundred)]
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
        [TestCategory(TC.Unit), TestCategory(TC.Adapter)]
        [Description("Create proxy with parameter.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
        [TestCategory(TC.Unit), TestCategory(TC.Adapter), TestCategory(TC.Negative)]
        [Description("Create adapter without createProxyFunc.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
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
