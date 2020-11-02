using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestCommon;

namespace ComboPatterns.FactoryTests
{
    [TestClass]
    public class CreateObjectTests : FactoryTestBase<Env.Factory>
    {
        [TestMethod]
        [TestCategory(TC.Unit), TestCategory(TC.Factory)]
        [Description("Create object.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateObjectTestCese()
        {
            GivenCreateFactory()
                .When("Create object", factory => factory.CreateObject(_ => new object(), (object)null))
                .Then("Check result", obj =>
                {
                    Assert.IsNotNull(obj, "object not created");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Unit), TestCategory(TC.Factory), TestCategory(TC.Negative)]
        [Description("Create object without func.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateObjectWithoutFuncTestCase()
        {
            GivenCreateFactory()
                .When("Create object", factory => ExpectedException<ArgumentNullException>(() => factory.CreateObject<object, object>(null, null)))
                .Then("Check result", ex =>
                {
                    Assert.IsNotNull(ex, "error cannot be null");
                    Assert.AreEqual("factoryFunc", ex.ParamName, "expected another message");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(TC.Unit), TestCategory(TC.Factory)]
        [Description("Create object with parameter.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public void CreateObjectWithParamTestCase()
        {
            object paramObj = new object();

            GivenCreateFactory()
                .When("Create object", factory => factory.CreateObject(param => new { param }, paramObj))
                .Then("Check result", obj =>
                {
                    Assert.IsNotNull(obj, "object not created");
                    Assert.AreEqual(paramObj, obj.param, "expected another parameter");
                })
                .Run();
        }
    }
}
