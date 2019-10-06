namespace ComboPatterns.AFAP.UnitTests.Entities
{
    public sealed class TestFacade: FacadeBase
    {
        public int CallGetFacadeCounter { get; private set; }
        public int CallGetAdapterCounter { get; private set; }

        public override TFacade GetFacade<TFacade>()
        {
            CallGetFacadeCounter++;
            return base.GetFacade<TFacade>();
        }

        public TAdapter GetAdapter2<TAdapter>()
            where TAdapter: AdapterBase, new()
        {
            CallGetAdapterCounter++;
            return GetAdapter<TAdapter>();
        }
    }
}
