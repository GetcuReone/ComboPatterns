using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP
{
    /// <summary>
    /// Implementation <see cref="IFacade"/>
    /// </summary>
    public abstract class FacadeBase : IFacade
    {
        private IAbstractFactory _factory;

        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        protected virtual TAdapter GetAdapter<TAdapter>() where TAdapter : AdapterBase, new()
            => AdapterBase.GetAdapterStatic<TAdapter>(_factory);

        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade">type of facade created</typeparam>
        /// <returns>facade <typeparamref name="TFacade"/></returns>
        public virtual TFacade GetFacade<TFacade>() where TFacade : IFacade, new() => GetFacadeStatic<TFacade>(_factory);

        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade">type of facade created</typeparam>
        /// <param name="factory">facade factory</param>
        /// <returns>facade <typeparamref name="TFacade"/></returns>
        public static TFacade GetFacadeStatic<TFacade>(IAbstractFactory factory)
             where TFacade : IFacade, new()
        {
            return factory.CreateObject<object, TFacade>(
                (_) => 
                {
                    var facade = new TFacade();

                    if (facade is FacadeBase facadeBase)
                        facadeBase._factory = factory;

                    return facade;
                },
                null);
        }
    }
}
