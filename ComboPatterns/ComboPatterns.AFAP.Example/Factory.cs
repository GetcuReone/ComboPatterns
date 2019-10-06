using System;

namespace ComboPatterns.AFAP.Example
{
    public class Factory: FactoryBase
    {
        public override TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            Console.WriteLine($"type obj '{typeof(TObj).Name}'");
            return base.CreateObject(factoryFunc, parameters);
        }

        public void Start()
        {
            Console.WriteLine("Run factory");
            GetFacade<Facade>().OurMethod();
        }
    }
}
