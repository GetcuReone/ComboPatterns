namespace GetcuReone.ComboPatterns.Interfaces
{
    /// <summary>
    /// Proxy creation interface
    /// </summary>
    /// <typeparam name="TProxy">type proxy</typeparam>
    public interface IProxyCreation<out TProxy>
    {
        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <returns></returns>
        TProxy GetProxy();
    }

    /// <summary>
    /// Proxy creation interface
    /// </summary>
    /// <typeparam name="TProxy">type proxy</typeparam>
    /// <typeparam name="TProxyParameter">type proxy parameter</typeparam>
    public interface IProxyCreation<out TProxy, in TProxyParameter>
    {
        /// <summary>
        /// Proxy creation method
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        TProxy GetProxy(TProxyParameter param);
    }
}
