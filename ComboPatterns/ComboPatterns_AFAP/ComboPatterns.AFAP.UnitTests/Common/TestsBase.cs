using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComboPatterns.AFAP.UnitTests.Common
{
    [TestClass]
    public abstract class TestsBase: FactoryBase
    {
        /// <summary>
        /// how many times the <see cref="CreateObject{TParameters, TObj}(Func{TParameters, TObj}, TParameters)"/> was called
        /// </summary>
        public int CallCreateObjectCounter { get; private set; }
        /// <summary>
        /// how many times the <see cref="GetFacade{TFacade}"/> was called
        /// </summary>
        public int CallGetFacadeCounter { get; private set; }

        /// <summary>
        /// how many times the <see cref="GetAdapter{TAdapter}"/> was called
        /// </summary>
        public int CallGetAdapterCounter { get; private set; }

        protected override TFacade GetFacade<TFacade>()
        {
            var result = base.GetFacade<TFacade>();
            CallGetFacadeCounter++;
            return result;
        }

        public TAdapter GetAdapter2<TAdapter>() where TAdapter: AdapterBase, new()
        {
            CallGetAdapterCounter++;
            return GetAdapter<TAdapter>();
        }

        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            var result = base.CreateObject(factoryFunc, parameters);
            CallCreateObjectCounter++;
            return result;
        }
    }
}
