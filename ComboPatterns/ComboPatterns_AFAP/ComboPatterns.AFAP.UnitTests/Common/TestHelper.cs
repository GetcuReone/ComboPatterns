using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace ComboPatterns.AFAP.UnitTests.Common
{
    public static class TestHelper
    {
        public static void AssertCounter(int expectedCounter, int counter, string methodNane)
        {
            if (expectedCounter != 0)
                Assert.AreNotEqual(0, counter, $"There was no method call {methodNane}");
            Assert.AreEqual(expectedCounter, counter,
                $"There should have been {expectedCounter} method {methodNane} calls. Fact: {counter}");
        }

        public static TExpectedException ExpectedException<TExpectedException>(Action action)
            where TExpectedException : Exception
        {
            try
            {
                action();
                throw new Exception("Did not appear exception");
            }
            catch (TExpectedException ex)
            {
                return ex;
            }
            catch (TargetInvocationException tex)
            {
                if (tex.InnerException is TExpectedException ex)
                    return ex;
                else
                    throw;
            }
            catch
            {
                throw;
            }
        }
    }
}
