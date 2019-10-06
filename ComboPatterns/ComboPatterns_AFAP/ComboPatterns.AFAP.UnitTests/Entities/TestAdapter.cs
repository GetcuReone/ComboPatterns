namespace ComboPatterns.AFAP.UnitTests.Entities
{
    public class TestAdapter: AdapterBase
    {
        public int CallGetAdapterCounter { get; private set; }

        public override TAdapter GetAdapter<TAdapter>()
        {
            CallGetAdapterCounter++;
            return base.GetAdapter<TAdapter>();
        }
    }
}
