using ComboPatterns.AdapterTests.Env;
using GetcuReone.ComboPatterns.Adapter;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AdapterTests
{
    [TestClass]
    public sealed class AdapterTests : FactoryTestBase<Factory>
    {
        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter] create adapter")]
        public void CreateAdapterTestCase()
        {
            GivenCreateFactory()
                .When("create adapter", _ => AdapterBase.Create<Adapter>(Factory))
                .Then("Check result", adapter =>
                {
                    Assert.IsNotNull(adapter, "adapter cannot be null");
                    Assert.AreEqual(1, Factory.CountCallCreateObject, "there should have been 1 call CreateObject");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter] bind factory")]
        public void BindFactoryTestCase()
        {
            GivenCreateFactory()
                .When("create adapter", _ => AdapterBase.Create<Adapter>(Factory))
                .Then("Check result", adapter =>
                {
                    adapter.AssertFactory(Factory);
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[adapter] get adapter")]
        public void GetAdapterTestCase()
        {
            Adapter adapter1 = null;
            Adapter adapter2 = null;

            GivenCreateFactory()
                .And("create adapter", _ =>
                {
                    adapter1 = AdapterBase.Create<Adapter>(Factory);
                })
                .When("get adapter", _ =>
                {
                    adapter2 = adapter1.GetAdapter<Adapter>();
                })
                .Then("Check result", facade =>
                {
                    Assert.IsNotNull(adapter2, "facade2 cannot be null");
                    Assert.AreNotEqual(adapter1, adapter2, "facades match");
                    Assert.AreEqual(1, adapter1.CountCallGetAdapter, "there should have been 1 call GetAdapter");
                    Assert.AreEqual(0, adapter2.CountCallGetAdapter, "there should have been 0 call GetAdapter");

                    Assert.AreEqual(2, Factory.CountCallCreateObject, "there should have been 1 call CreateObject");
                });
        }
    }
}
