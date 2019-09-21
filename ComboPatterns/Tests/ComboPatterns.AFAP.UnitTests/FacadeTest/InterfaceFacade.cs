using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP.UnitTests.FacadeTest
{
    public sealed class InterfaceFacade : IFacade
    {
        public TFacade GetFacade<TFacade>() where TFacade : IFacade, new()
        {
            throw new NotImplementedException();
        }
    }
}
