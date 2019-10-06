namespace ComboPatterns.AFAP.UnitTests.Entities
{
    public sealed class TestProxy<TObj>
    {
        public TestProxy(TObj obj)
        {
            Obj = obj;
        }

        public TObj Obj { get;}
    }
}
