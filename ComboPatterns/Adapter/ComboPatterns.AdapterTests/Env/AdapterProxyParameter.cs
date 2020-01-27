using GetcuReone.ComboPatterns.Adapter;

namespace ComboPatterns.AdapterTests.Env
{
    public sealed class AdapterProxyParameter : AdapterProxyBase<Proxy<object>, object>
    {
        public AdapterProxyParameter() : base(parm => new Proxy<object> { Param = parm })
        {
        }
    }
}
