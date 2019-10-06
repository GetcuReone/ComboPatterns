using ComboPatterns.AFAP.UnitTests.Common;

namespace ComboPatterns.AFAP.UnitTests.Asserts
{
    public static class AssertFactory
    {
        public static void AssertCounters(TestsBase factory,
            int? callCreateObjectCounter = null,
            int? callGetFacadeCounter = null,
            int? callGetAdapterCounter = null)
        {
            if (callCreateObjectCounter.HasValue)
                TestHelper.AssertCounter(callCreateObjectCounter.Value, factory.CallCreateObjectCounter, nameof(FactoryBase.CreateObject));
            if (callGetFacadeCounter.HasValue)
                TestHelper.AssertCounter(callGetFacadeCounter.Value, factory.CallGetFacadeCounter, "GetFacade");
            if (callGetAdapterCounter.HasValue)
                TestHelper.AssertCounter(callGetAdapterCounter.Value, factory.CallGetAdapterCounter, "GetAdapter");
        }
    }
}
