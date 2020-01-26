using GetcuReone.ComboPatterns.Adapter;

namespace ComboPatterns.AdapterTests.Env
{
    public sealed class InvalidAdapterProxyParameter : AdapterProxyBase<object, object>
    {
        public InvalidAdapterProxyParameter() : base(null)
        {
        }
    }
}
