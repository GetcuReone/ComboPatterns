using System;

namespace ComboPatterns.AFAP.Example
{
    public class Facade: FacadeBase
    {
        public void OurMethod()
        {
            Console.WriteLine("Start OurMethod");
            long obj = GetAdapter<Adapter>().Convert("65");
            GetAdapter<AdapterProxy>().GetUtcDateTime();
        }
    }
}
