using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using ComboPatterns.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.Asserts
{
    public static class AssertAdapter
    {
        public static void NullAndType<TAdapterCompare>(IAdapter adapter)
            where TAdapterCompare : IAdapter
        {
            Assert.IsNotNull(adapter, "adapter should not be null");
            Assert.IsTrue(adapter is TAdapterCompare, "facade must be other type");
        }

        public static void AssertCounter(
            TestAdapter adapter,
            int? callGetAdapterCounter = null)
        {
            if (callGetAdapterCounter.HasValue)
                TestHelper.AssertCounter(callGetAdapterCounter.Value, adapter.CallGetAdapterCounter, nameof(AdapterBase.GetAdapter));
        }
    }
}
