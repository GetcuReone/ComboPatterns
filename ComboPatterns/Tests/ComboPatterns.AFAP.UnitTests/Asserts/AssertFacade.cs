using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using ComboPatterns.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.Asserts
{
    public static class AssertFacade
    {
        public static void NullAndType<TFacadeCompare>(IFacade facade)
            where TFacadeCompare: IFacade
        {
            Assert.IsNotNull(facade, "facade should not be null");
            Assert.IsTrue(facade is TFacadeCompare, "facade must be other type");
        }

        public static void AssertCounter(TestFacade facade, int? callGetFacadeCounter = null, int? callGetAdapterCounter = null)
        {
            if (callGetFacadeCounter.HasValue)
                TestHelper.AssertCounter(callGetFacadeCounter.Value, facade.CallGetFacadeCounter, nameof(FacadeBase.GetFacade));
            if (callGetAdapterCounter.HasValue)
                TestHelper.AssertCounter(callGetAdapterCounter.Value, facade.CallGetAdapterCounter, "GetAdapter");
        }
    }
}
