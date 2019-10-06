using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP.UnitTests.Entities
{
    public sealed class TestInterfaceFactory : IAbstractFactory
    {
        /// <summary>
        /// how many times the <see cref="CreateObject{TParameters, TObj}(Func{TParameters, TObj}, TParameters)"/> was called
        /// </summary>
        public int CallCreateObjectCounter { get; private set; }

        public TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            CallCreateObjectCounter++;
            return factoryFunc(parameters);
        }
    }
}
