using System;
using System.Collections.Generic;
using System.Text;

namespace ComboPatterns.AFAP.Example
{
    public class AdapterProxy: AdapterProxyBase<DateTime>
    {
        public AdapterProxy() : base(() => DateTime.UtcNow) { }

        public DateTime GetUtcDateTime()
        {
            var result = CreateProxy();
            Console.WriteLine($"method GetUtcDateTime: {result}");
            return result;
        }
    }
}
