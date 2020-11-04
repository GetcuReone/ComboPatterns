using GetcuReone.ComboPatterns.Interfaces;
using System;

namespace GetcuReone.ComboPatterns.Factory
{
    /// <summary>
    /// abstract object creation factory.
    /// </summary>
    public class FactoryBase : IAbstractFactory
    {
        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">if <paramref name="factoryFunc"/> is null.</exception>
        public virtual TObj CreateObject<TParameter, TObj>(Func<TParameter, TObj> factoryFunc, TParameter parameter)
        {
            if (factoryFunc == null)
                throw new ArgumentNullException(nameof(factoryFunc), $"Input function is null.");

            return factoryFunc(parameter);
        }
    }
}
