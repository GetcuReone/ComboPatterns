using System;

namespace ComboPatterns.Interfaces
{
    /// <summary>
    /// Abstract factory interface
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Object Creation Method
        /// </summary>
        /// <typeparam name="TObj">type of object to create</typeparam>
        /// <typeparam name="TParameters">type of parameters for creating an object</typeparam>
        /// <param name="factoryFunc">function to create objects</param>
        /// <param name="parameters">options for creating an object</param>
        /// <returns>object</returns>
        TObj CreateObject<TParameters, TObj>(Func<TParameters, TObj> factoryFunc, TParameters parameters);
    }
}
