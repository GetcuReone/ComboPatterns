using GetcuReone.ComboPatterns.Interfaces;
using System;

namespace GetcuReone.ComboPatterns.Factory
{
    /// <summary>
    /// abstract object creation factory.
    /// </summary>
    public class FactoryBase : IAbstractFactory
    {
        /// <summary>
        /// Object creation method.
        /// </summary>
        /// <typeparam name="TObj">type of object to create.</typeparam>
        /// <typeparam name="TParameter">type of parameters for creating an object.</typeparam>
        /// <param name="factoryFunc">function to create objects.</param>
        /// <param name="parameter">options for creating an object.</param>
        /// <exception cref="ArgumentNullException">if <paramref name="factoryFunc"/> is null.</exception>
        /// <returns>object</returns>
        public virtual TObj CreateObject<TParameter, TObj>(Func<TParameter, TObj> factoryFunc, TParameter parameter)
        {
            if (factoryFunc == null)
                throw new ArgumentNullException(nameof(factoryFunc), $"should not be null");

            return factoryFunc(parameter);
        }
    }
}
