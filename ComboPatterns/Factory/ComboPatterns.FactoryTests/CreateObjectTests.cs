using JwtTestAdapter;
using JwtTestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComboPatterns.FactoryTests
{
    [TestClass]
    public class CreateObjectTests : TestBase
    {

        private GivenBlock<Env.Factory> GivenCreateFactory()
        {
            return Given("Create factory", () => new Env.Factory());
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[factory] create object")]
        public void CreateObjectTestCese()
        {
            GivenCreateFactory()
                .When("Create object", factory => factory.CreateObject(_ => new object(), (object)null))
                .Then("Check result", obj =>
                {
                    Assert.IsNotNull(obj, "object not created");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[factory][negative] create object without func")]
        public void CreateObjectWithoutFuncTestCase()
        {
            GivenCreateFactory()
                .When("Create object", factory => ExpectedException<ArgumentNullException>(() => factory.CreateObject<object, object>(null, null)))
                .Then("Check result", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.AreEqual("factoryFunc", ex.ParamName, "expected another message");
                });
        }

        [TestMethod]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        [Description("[factory] create object with parameter")]
        public void CreateObjectWithParamTestCase()
        {
            object paramObj = new object();

            GivenCreateFactory()
                .When("Create object", factory => factory.CreateObject(param => new { param }, paramObj))
                .Then("Check result", obj =>
                {
                    Assert.IsNotNull(obj, "object not created");
                    Assert.AreEqual(paramObj, obj.param, "expected another parameter");
                });
        }
    }
}
