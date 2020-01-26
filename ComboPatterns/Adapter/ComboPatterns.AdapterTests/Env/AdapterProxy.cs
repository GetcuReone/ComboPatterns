using GetcuReone.ComboPatterns.Adapter;

namespace ComboPatterns.AdapterTests.Env
{
    public sealed class AdapterProxy : AdapterProxyBase<Proxy>
    {
        public AdapterProxy() : base(() => new Proxy())
        {
        }
    }
}
