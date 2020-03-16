using ComboPatterns.FacadeTests.Env;
using GetcuReone.ComboPatterns.Facade;
using JwtTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.FacadeTests
{
    [TestClass]
    public sealed class FacadeTests : FactoryTestBase<Factory>
    {
        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[facade] create facade")]
        public void CreateFacadeTestCase()
        {
            GivenCreateFactory()
                .When("create facade", _ => FacadeBase.Create<Facade>(Factory))
                .Then("Check result", facade =>
                {
                    Assert.IsNotNull(facade, "facade cannot be null");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[facade] bind factory")]
        public void BindFactoryTestCase()
        {
            GivenCreateFactory()
                .When("create facade", _ => FacadeBase.Create<Facade>(Factory))
                .Then("Check result", facade =>
                {
                    facade.AssertFactory(Factory);
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[facade] get facade")]
        public void GetFacadeTestCase()
        {
            Facade facade1 = null;
            Facade facade2 = null;

            GivenCreateFactory()
                .And("create facade", _ => 
                {
                    facade1 = FacadeBase.Create<Facade>(Factory);
                })
                .When("get facade", _ =>
                {
                    facade2 = facade1.GetFacade<Facade>();
                })
                .Then("Check result", facade =>
                {
                    Assert.IsNotNull(facade2, "facade2 cannot be null");
                    Assert.AreNotEqual(facade1, facade2, "facades match");
                    Assert.AreEqual(1, facade1.CountCallGetFacade, "there should have been 1 call GetFacade");
                    Assert.AreEqual(0, facade2.CountCallGetFacade, "there should have been 0 call GetFacade");
                });
        }
    }
}
