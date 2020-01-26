using System;
using System.Collections.Generic;
using System.Text;

namespace ComboPatterns.AdapterTests.Env
{
    public class Proxy
    {
    }

    public class Proxy<TParam>
    {
        public TParam Param { get; set; }
    }
}
