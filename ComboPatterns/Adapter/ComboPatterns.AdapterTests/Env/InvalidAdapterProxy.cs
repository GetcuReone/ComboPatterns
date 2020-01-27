using GetcuReone.ComboPatterns.Adapter;

namespace ComboPatterns.AdapterTests.Env
{
    public sealed class InvalidAdapterProxy : AdapterProxyBase<Proxy>
    {
        public InvalidAdapterProxy() : base(null)
        {
        }
    }
}
