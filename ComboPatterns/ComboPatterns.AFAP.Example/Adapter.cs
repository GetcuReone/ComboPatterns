using System;

namespace ComboPatterns.AFAP.Example
{
    public class Adapter: AdapterBase
    {
        public long Convert(string longStr)
        {
            var result = System.Convert.ToInt64(longStr);
            Console.WriteLine($"method Convert: {result}");
            return result;
        }
    }
}
