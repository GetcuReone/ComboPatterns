using ComboPatterns.AFAP.UnitTests.Asserts;
using ComboPatterns.AFAP.UnitTests.Common;
using ComboPatterns.AFAP.UnitTests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComboPatterns.AFAP.UnitTests.FactoryTests
{
    [TestClass]
    public class FactoryTests : TestsBase
    {
        [TestMethod]
        [Description("[factory] Creation object without parameters")]
        [Timeout(Timeuot.Millisecond.Hundred)]
        public void CreateObjectWithoutParamTestCase()
        {
            string excpectedText = "Hello";

            string text = CreateObject<object, string>((_) => FactoryTestsHelper.GetHello(), null);

            Assert.AreEqual(excpectedText, text, $"expected: '{excpectedText}' fact: {text}");
            AssertFactory.AssertCounters(this, callCreateObjectCounter: 1);
        }

        [TestMethod]
        [Description("[factory] Creation object with parameters")]
        [Timeout(Timeuot.Millisecond.Twenty)]
        public void CreateObjectWithParamTestCase()
        {
            double excpectedSqr = 5;

            double result = CreateObject((param) => Math.Sqrt(param), 25);

            Assert.AreEqual(excpectedSqr, result, $"expected: '{excpectedSqr}' fact: {result}");
            AssertFactory.AssertCounters(this, callCreateObjectCounter: 1);
        }

        [TestMethod]
        [Description("[factory] Creation facade")]
        [Timeout(Timeuot.Millisecond.Hundred)]
        public void GetFacadeTestCase()
        {
            var result = GetFacade<TestFacade>();

            AssertFacade.NullAndType<TestFacade>(result);
            AssertFactory.AssertCounters(this, callCreateObjectCounter: 1,
                           callGetFacadeCounter: 1);
        }

        [TestMethod]
        [Description("[factory] Creation adapter")]
        [Timeout(Timeuot.Millisecond.Hundred)]
        public void GetAdapterTestCase()
        {
            var result = GetAdapter2<TestAdapter>();

            AssertAdapter.NullAndType<TestAdapter>(result);
            AssertFactory.AssertCounters(this, callCreateObjectCounter: 1,
                           callGetFacadeCounter: 0,
                           callGetAdapterCounter: 1);
        }
    }
}
