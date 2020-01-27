namespace GetcuReone.ComboPatterns.Interfaces
{
    /// <summary>
    /// Facade creation interface
    /// </summary>
    public interface IFacadeCreation
    {
        /// <summary>
        /// Facade creation method
        /// </summary>
        /// <typeparam name="TFacade">type of facade created</typeparam>
        /// <returns>facade <typeparamref name="TFacade"/></returns>
        TFacade GetFacade<TFacade>() where TFacade : IFacade, new();
    }
}
