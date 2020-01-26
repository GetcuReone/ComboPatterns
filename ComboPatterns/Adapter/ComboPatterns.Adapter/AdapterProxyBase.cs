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
}
