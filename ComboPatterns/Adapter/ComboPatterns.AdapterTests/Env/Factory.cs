using GetcuReone.ComboPatterns.Factory;
using System;

namespace ComboPatterns.AdapterTests.Env
{
    public sealed class Factory : FactoryBase
    {
        public int CountCallCreateObject { get; private set; }

        public override TObj CreateObject<TParameter, TObj>(Func<TParameter, TObj> factoryFunc, TParameter parameter)
        {
            CountCallCreateObject++;
            return base.CreateObject(factoryFunc, parameter);
        }
    }
}
