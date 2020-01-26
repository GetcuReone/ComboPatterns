using ComboPatterns.AdapterTests.Env;
using ComboPatterns.FactoryTests;
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
    }
}
