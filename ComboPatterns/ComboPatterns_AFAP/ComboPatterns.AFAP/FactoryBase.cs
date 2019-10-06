using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP
{
    /// <summary>
    /// Implementation <see cref="IAbstractFactory"/>
    /// </summary>
    public abstract class FactoryBase : IAbstractFactory
    {
        /// <summary>
        /// Object Creation Method
        /// </summary>
        /// <typeparam name="TObj">type of object to create</typeparam>
        /// <typeparam name="TParameters">type of parameters for creating an object</typeparam>
        /// <param name="factoryFunc">function to create objects</param>
        /// <param name="parameters">options for creating an object</param>
        /// <returns>object</returns>
        public virtual TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters)
        {
            if (factoryFunc == null)
                throw new ArgumentNullException(nameof(factoryFunc), $"{nameof(factoryFunc)} should not be null");

            return factoryFunc(parameters);
        }

        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade">type of facade created</typeparam>
        /// <returns>facade <typeparamref name="TFacade"/></returns>
        protected virtual TFacade GetFacade<TFacade>() where TFacade : FacadeBase, new()
            => FacadeBase.GetFacadeStatic<TFacade>(this);

        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        protected virtual TAdapter GetAdapter<TAdapter>() where TAdapter : AdapterBase, new()
            => AdapterBase.GetAdapterStatic<TAdapter>(this);
    }
}
