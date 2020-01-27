using GetcuReone.ComboPatterns.Interfaces;
using System;

namespace GetcuReone.ComboPatterns.Adapter
{
    /// <summary>
    /// base class for adapters with proxy call support
    /// </summary>
    /// <typeparam name="TProxy">type proxy</typeparam>
    public abstract class AdapterProxyBase<TProxy> : AdapterBase, IProxyCreation<TProxy>
    {
        private readonly Func<TProxy> _createProxyFunc;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createProxyFunc">func creation proxy</param>
        protected AdapterProxyBase(Func<TProxy> createProxyFunc)
        {
            _createProxyFunc = createProxyFunc 
                ?? throw new ArgumentNullException(nameof(createProxyFunc), $"Func creation proxy must be not null");
        }

        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <returns></returns>
        public virtual TProxy CreateProxy()
        {
            return Factory.CreateObject<object, TProxy>((_) => _createProxyFunc(), null);
        }
    }

    /// <summary>
    /// base class for adapters with proxy call support
    /// </summary>
    /// <typeparam name="TProxy">type proxy</typeparam>
    /// <typeparam name="TProxyParameter">type proxy parameter</typeparam>
    public abstract class AdapterProxyBase<TProxy, TProxyParameter> : AdapterBase, IProxyCreation<TProxy, TProxyParameter>
    {
        private readonly Func<TProxyParameter, TProxy> _createProxyFuncWithParam;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createProxyFuncWithParam">Func creation proxy with parameters type <typeparamref name="TProxyParameter"/></param>
        protected AdapterProxyBase(Func<TProxyParameter, TProxy> createProxyFuncWithParam)
        {
            _createProxyFuncWithParam = createProxyFuncWithParam 
                ?? throw new ArgumentNullException(nameof(createProxyFuncWithParam), $"Func creation proxy with param must be not null");
        }

        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <param name="parameter">proxy parameter</param>
        /// <returns>proxy</returns>
        public virtual TProxy CreateProxy(TProxyParameter parameter)
        {
            return Factory.CreateObject(_createProxyFuncWithParam, parameter);
        }
    }
}
