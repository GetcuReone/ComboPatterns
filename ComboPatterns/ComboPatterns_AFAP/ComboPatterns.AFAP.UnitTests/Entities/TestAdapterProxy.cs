using System;

namespace ComboPatterns.AFAP.UnitTests.Entities
{
    public class TestAdapterProxy : AdapterProxyBase<TestProxy<object>>
    {
        public int CallCreateProxyCounter { get; private set; }
        public TestAdapterProxy() : base(() => new TestProxy<object>(null))
        {
        }

        public override TestProxy<object> CreateProxy()
        {
            CallCreateProxyCounter++;
            return base.CreateProxy();
        }
    }

    public class TestAdapterProxy<TProxyParameter> : AdapterProxyBase<TestProxy<TProxyParameter>, TProxyParameter>
    {
        public TestAdapterProxy() : base(() => new TestProxy<TProxyParameter>(default), (p) => new TestProxy<TProxyParameter>(p))
        {
        }

        public int CallCreateProxyCounter { get; private set; }

        public override TestProxy<TProxyParameter> CreateProxy(TProxyParameter parameter)
        {
            CallCreateProxyCounter++;
            return base.CreateProxy(parameter);
        }
    }
}
