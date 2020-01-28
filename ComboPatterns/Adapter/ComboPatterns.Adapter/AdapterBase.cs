using GetcuReone.ComboPatterns.Interfaces;

namespace GetcuReone.ComboPatterns.Adapter
{
    /// <summary>
    /// Base class for adapteres
    /// </summary>
    public abstract class AdapterBase : IAdapter
    {
        /// <summary>
        /// Factory creating the current adapter
        /// </summary>
        protected virtual IAbstractFactory Factory { get; private set; }

        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        public virtual TAdapter GetAdapter<TAdapter>() where TAdapter : IAdapter, new()
        {
            return Create<TAdapter>(Factory);
        }

        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static TAdapter Create<TAdapter>(IAbstractFactory factory)
            where TAdapter : IAdapter, new()
        {
            return factory.CreateObject<object, TAdapter>(
                (_) =>
                {
                    var adapter = new TAdapter();

                    if (adapter is AdapterBase adapterBase)
                        adapterBase.Factory = factory;

                    return adapter;
                },
                null);
        }
    }
}
