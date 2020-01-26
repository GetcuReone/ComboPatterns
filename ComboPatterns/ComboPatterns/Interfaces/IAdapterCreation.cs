namespace GetcuReone.ComboPatterns.Interfaces
{
    /// <summary>
    /// Adapter creation interface
    /// </summary>
    public interface IAdapterCreation
    {
        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        TAdapter GetAdapter<TAdapter>() where TAdapter : IAdapter, new();
    }
}
