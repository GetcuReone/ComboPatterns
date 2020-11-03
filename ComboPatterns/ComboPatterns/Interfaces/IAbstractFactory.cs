using System;
using System.Threading.Tasks;

namespace GetcuReone.ComboPatterns.Interfaces
{
    /// <summary>
    /// Abstract factory interface.
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Object creation method.
        /// </summary>
        /// <typeparam name="TObj">type of object to create.</typeparam>
        /// <typeparam name="TParameter">type of parameters for creating an object.</typeparam>
        /// <param name="factoryFunc">function to create objects.</param>
        /// <param name="parameters">options for creating an object.</param>
        /// <returns>object</returns>
        TObj CreateObject<TParameter, TObj>(Func<TParameter, TObj> factoryFunc, TParameter parameters);

        /// <summary>
        /// Asynchronous object creation.
        /// </summary>
        /// <typeparam name="TObj">type of object to create.</typeparam>
        /// <typeparam name="TParameter">type of parameters for creating an object.</typeparam>
        /// <param name="factoryFunc">function to create objects.</param>
        /// <param name="parameters">options for creating an object.</param>
        /// <returns>object</returns>
        ValueTask<TObj> CreateObjectAsync<TParameter, TObj>(Func<TParameter, ValueTask<TObj>> factoryFunc, TParameter parameters);
    }
}
