using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComboPatterns.AFAP.UnitTests.FacadeTest
{
    [TestClass]
    public class FacadeTests: FacadeTestsBase
    {
        [TestMethod]
        [Description("[facade] Creation facade")]
        [Timeout(Timeuot.Millisecond.Hundred)]
        public void GetFacadeTestCase()
        {
            var result = Facade.GetFacade<Facade>();

            AssertFacadeTestObj(1);
            AssertFacade.AssertCounter(Facade, callGetFacadeCounter: 1);

            AssertFacade.NullAndType<Facade>(result);
        }

        [TestMethod]
        [Description("[facade] Creation facade same type.")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetFacadeSameTypeTestCase()
        {
            var result = Facade.GetFacade<TestFacade>();

            AssertFacadeTestObj(1);
            AssertFacade.AssertCounter(Facade, callGetFacadeCounter: 1);

            AssertFacade.NullAndType<TestFacade>(result);
            AssertFacade.AssertCounter(result, callGetFacadeCounter: 0);
            Assert.AreNotEqual(Facade, result, "must be different facade");
        }

        [TestMethod]
        [Description("[facade] Creation adapter")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetAdapterTestCase()
        {
            var result = Facade.GetAdapter2<TestAdapter>();

            AssertFacadeTestObj(1);
            AssertFacade.AssertCounter(Facade, callGetAdapterCounter: 1);

            AssertAdapter.NullAndType<TestAdapter>(result);
        }

        [TestMethod]
        [Description("[facade] Creation facade imlement interface")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void GetFacadeInterfaceTestCase()
        {
            var result = Facade.GetFacade<InterfaceFacade>();

            AssertFacadeTestObj(1);
            AssertFacade.AssertCounter(Facade, callGetFacadeCounter: 1);

            AssertFacade.NullAndType<InterfaceFacade>(result);
        }
    }
}
