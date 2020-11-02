using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TestCommon;

namespace ComboPatterns.FactoryTests
{
    [TestClass]
    public sealed class CreateObjectAsyncTests : FactoryTestBase<Env.Factory>
    {
        [TestMethod]
        [TestCategory(TC.Unit), TestCategory(TC.Factory)]
        [Description("Create object.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public async Task CreateObjectAsyncTestCese()
        {
            await GivenCreateFactory()
                .WhenAsync("Create object", factory => 
                    factory.CreateObjectAsync(_ => new ValueTask<object>(new object()), (object)null))
                .ThenIsNotNull(errorMessage: "object not created.")
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Unit), TestCategory(TC.Factory), TestCategory(TC.Negative)]
        [Description("Create object without func.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public async Task CreateObjectAsyncWithoutFuncTestCase()
        {
            const string paramName = "factoryFunc";

            await GivenCreateFactory()
                .WhenAsync("Create object", async factory =>
                {
                    Func<object, ValueTask<object>> func = null;

                    try
                    {
                        await factory.CreateObjectAsync(func, null);
                    }
                    catch (ArgumentNullException ex)
                    {
                        return ex;
                    }

                    return null;
                })
                .ThenIsNotNull(errorMessage: "error cannot be null.")
                .AndAreEqual(ex => ex.ParamName, paramName,
                    errorMessage: "expected another message.")
                .RunAsync();
        }

        [TestMethod]
        [TestCategory(TC.Unit), TestCategory(TC.Factory)]
        [Description("Create object with parameter.")]
        [Timeout(Timeouts.MilliSecond.Hundred)]
        public async Task CreateObjectAsyncWithParamTestCase()
        {
            object paramObj = new object();

            await GivenCreateFactory()
                .WhenAsync("Create object", factory => factory.CreateObjectAsync(param => new ValueTask<object>(param), paramObj))
                .ThenIsNotNull(errorMessage: "object not created.")
                .AndAreEqual(paramObj, 
                    errorMessage: "expected another parameter.")
                .RunAsync();
        }
    }
}
