namespace ComboPatterns.Interfaces
{
    /// <summary>
    /// Intarface factory proxy creation proxy
    /// </summary>
    /// <typeparam name="TProxy"></typeparam>
    public interface IFactoryProxyMethod<out TProxy>
    {
        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <returns>proxy</returns>
        TProxy CreateProxy();
    }

    /// <summary>
    /// Intarface factory proxy creation proxy
    /// </summary>
    /// <typeparam name="TProxy"></typeparam>
    /// <typeparam name="TProxyParameter"></typeparam>
    public interface IFactoryProxyMethod<out TProxy, TProxyParameter> : IFactoryProxyMethod<TProxy>
    {
        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <param name="parameter">parameter</param>
        /// <returns>proxy</returns>
        TProxy CreateProxy(TProxyParameter parameter);
    }
}
