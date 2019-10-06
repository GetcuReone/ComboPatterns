using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP.UnitTests.AdapterTests.Entities
{
    public sealed class InterfaceAdapter : IAdapter
    {
        public TAdapter GetAdapter<TAdapter>() where TAdapter : IAdapter, new()
        {
            throw new NotImplementedException();
        }
    }
}
