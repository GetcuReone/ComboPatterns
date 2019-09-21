namespace ComboPatterns.Interfaces
{
    /// <summary>
    /// Facade interface
    /// </summary>
    public interface IFacade
    {
        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade">type of facade created</typeparam>
        /// <returns>facade <typeparamref name="TFacade"/></returns>
        TFacade GetFacade<TFacade>() where TFacade : IFacade, new();
    }
}
