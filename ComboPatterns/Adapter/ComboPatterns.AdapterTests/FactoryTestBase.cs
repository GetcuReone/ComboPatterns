using GetcuReone.ComboPatterns.Factory;
using GetcuReone.GwtTestFramework;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AdapterTests
{
    [TestClass]
    public abstract class FactoryTestBase<TFactory> : TestBase
        where TFactory : FactoryBase, new()
    {
        protected TFactory Factory { get; private set; }

        protected GivenBlock<TFactory, TFactory> GivenCreateFactory()
        {
            return Given("Create factory", () => new TFactory())
                .And("Set factory", factory => Factory = factory);
        }
    }
}
