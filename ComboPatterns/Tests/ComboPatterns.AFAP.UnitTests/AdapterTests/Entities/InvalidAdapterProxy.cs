namespace ComboPatterns.AFAP.UnitTests.AdapterTests.Entities
{
    public class InvalidAdapterProxy : AdapterProxyBase<object>
    {
        public InvalidAdapterProxy() : base(null)
        {
        }
    }

    public class InvalidAdapterProxy<TParam>: AdapterProxyBase<object, TParam>
    {
        public InvalidAdapterProxy() : base(() => new object(), null)
        {
        }
    }
}
