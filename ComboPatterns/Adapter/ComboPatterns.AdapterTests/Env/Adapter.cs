using GetcuReone.ComboPatterns.Adapter;
using GetcuReone.ComboPatterns.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.AdapterTests.Env
{
    public sealed class Adapter : AdapterBase
    {
        public int CountCallGetAdapter { get; private set; }

        public override TAdapter GetAdapter<TAdapter>()
        {
            CountCallGetAdapter++;
            return base.GetAdapter<TAdapter>();
        }

        public void AssertFactory(IAbstractFactory factory)
        {
            Assert.AreEqual(factory, Factory, "factories different");
        }
    }
}
