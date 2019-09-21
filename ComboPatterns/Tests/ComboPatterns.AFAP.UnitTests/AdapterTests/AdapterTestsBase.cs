using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.AdapterTests
{
    [TestClass]
    public abstract class AdapterTestsBase: TestsBase
    {
        private TestFacade _facade;
        protected TestAdapter Adapter { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            _facade = GetFacade<TestFacade>();

            AssertFactory.AssertCounters(this,
                callCreateObjectCounter: 1,
                callGetFacadeCounter: 1);

            Adapter = _facade.GetAdapter2<TestAdapter>();
            AssertFacade.AssertCounter(_facade, callGetAdapterCounter: 1);

            AssertFactory.AssertCounters(this,
                callCreateObjectCounter: 2,
                callGetFacadeCounter: 1);
        }

        protected void AssertCreateObjectNumber(int callGetAdapterCounter)
        {
            AssertFactory.AssertCounters(this,
                callCreateObjectCounter: 2 + callGetAdapterCounter,
                callGetFacadeCounter: 1);

            AssertFacade.AssertCounter(_facade, callGetAdapterCounter: 1);
        }
    }
}
