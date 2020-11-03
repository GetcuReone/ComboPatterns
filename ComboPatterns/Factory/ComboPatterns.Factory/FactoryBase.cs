using GetcuReone.ComboPatterns.Interfaces;
using System;
using System.Threading.Tasks;

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

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">if <paramref name="factoryFunc"/> is null.</exception>
        public virtual ValueTask<TObj> CreateObjectAsync<TParameter, TObj>(Func<TParameter, ValueTask<TObj>> factoryFuncAsync, TParameter parameters)
        {
            if (factoryFuncAsync == null)
                throw new ArgumentNullException(nameof(factoryFuncAsync), $"Input function is null.");

            return factoryFuncAsync(parameters);
        }
    }
}
