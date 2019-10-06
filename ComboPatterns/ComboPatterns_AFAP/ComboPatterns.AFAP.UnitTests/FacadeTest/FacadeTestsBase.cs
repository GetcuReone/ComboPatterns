using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AFAP.UnitTests.FacadeTest
{
    [TestClass]
    public abstract class FacadeTestsBase : TestsBase
    {
        protected TestFacade Facade { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Facade = GetFacade<TestFacade>();

            AssertFactory.AssertCounters(this,
                callCreateObjectCounter: 1,
                callGetFacadeCounter: 1);
        }

        protected void AssertFacadeTestObj(int callGetFacadeCounter)
        {
            AssertFactory.AssertCounters(this,
                callCreateObjectCounter: 1 + callGetFacadeCounter,
                callGetFacadeCounter: 1);
        }
    }
}
