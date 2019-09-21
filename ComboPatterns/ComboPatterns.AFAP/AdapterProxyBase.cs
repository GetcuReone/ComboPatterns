using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP
{
    /// <summary>
    /// Implement <see cref="IFactoryProxyMethod{TProxy}"/> and <see cref="AdapterBase"/>
    /// </summary>
    public abstract class AdapterProxyBase<TProxy> : AdapterBase, IFactoryProxyMethod<TProxy>
    {
        private readonly Func<TProxy> _createProxyFunc;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createProxyFunc">Func creation proxy</param>
        protected AdapterProxyBase(Func<TProxy> createProxyFunc)
        {
            _createProxyFunc = createProxyFunc ?? throw new ArgumentNullException(nameof(createProxyFunc), $"Func creation proxy must be not null");
        }

        /// <summary>
        /// Proxy creation method 
        /// </summary>
        /// <returns>proxy</returns>
        public virtual TProxy CreateProxy() => _factory.CreateObject<object, TProxy>((_) => _createProxyFunc(), null);
    }

    /// <summary>
    /// Implement <see cref="IFactoryProxyMethod{TProxy, TProxyParameter}"/> and <see cref="AdapterProxyBase{TProxy}"/>
    /// </summary>
    /// <typeparam name="TProxy"></typeparam>
    /// <typeparam name="TProxyParameter"></typeparam>
    public abstract class AdapterProxyBase<TProxy, TProxyParameter> : AdapterProxyBase<TProxy>, IFactoryProxyMethod<TProxy, TProxyParameter>
    {

        private readonly Func<TProxyParameter, TProxy> _createProxyFuncWithParam;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createProxyFunc">Func creation proxy</param>
        /// <param name="createProxyFuncWithParam">Func creation proxy with parameters type <typeparamref name="TProxyParameter"/></param>
        protected AdapterProxyBase(Func<TProxy> createProxyFunc, Func<TProxyParameter, TProxy> createProxyFuncWithParam)
            :base(createProxyFunc)
        {
            _createProxyFuncWithParam = createProxyFuncWithParam ?? throw new ArgumentNullException(nameof(createProxyFuncWithParam), $"Func creation proxy with param must be not null"); ;
        }

        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <param name="parameter">proxy parameter</param>
        /// <returns>proxy</returns>
        public virtual TProxy CreateProxy(TProxyParameter parameter) => _factory.CreateObject(_createProxyFuncWithParam, parameter);
    }
}
