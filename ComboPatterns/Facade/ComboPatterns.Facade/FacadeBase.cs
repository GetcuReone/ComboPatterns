using GetcuReone.ComboPatterns.Interfaces;

namespace GetcuReone.ComboPatterns.Facade
{
    /// <summary>
    /// Base class for facades
    /// </summary>
    public abstract class FacadeBase : IFacade
    {
        /// <summary>
        /// Factory creating the current facade
        /// </summary>
        protected virtual IAbstractFactory Factory { get; private set; }

        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade">type of facade created</typeparam>
        /// <returns>facade <typeparamref name="TFacade"/></returns>
        public virtual TFacade GetFacade<TFacade>() where TFacade : IFacade, new()
        {
            return Create<TFacade>(Factory);
        }

        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static TFacade Create<TFacade>(IAbstractFactory factory)
            where TFacade : IFacade, new()
        {
            return factory.CreateObject<object, TFacade>(
                (_) =>
                {
                    var facade = new TFacade();

                    if (facade is FacadeBase facadeBase)
                        facadeBase.Factory = factory;

                    return facade;
                },
                null);
        }
    }
}
