using GetcuReone.ComboPatterns.Facade;
using GetcuReone.ComboPatterns.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComboPatterns.FacadeTests.Env
{
    public sealed class Facade : FacadeBase
    {
        public int CountCallGetFacade { get; private set; }

        public override TFacade GetFacade<TFacade>()
        {
            CountCallGetFacade++;
            return base.GetFacade<TFacade>();
        }

        public void AssertFactory(IAbstractFactory factory)
        {
            Assert.AreEqual(factory, Factory, "factories different");
        }
    }
}
