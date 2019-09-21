using ComboPatterns.Interfaces;
using System;

namespace ComboPatterns.AFAP
{
    /// <summary>
    /// Implementation <see cref="IAdapter"/>
    /// </summary>
    public abstract class AdapterBase : IAdapter
    {
        protected private IAbstractFactory _factory;

        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        public virtual TAdapter GetAdapter<TAdapter>() where TAdapter : IAdapter, new() => GetAdapterStatic<TAdapter>(_factory);

        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <param name="factory">adapter factory</param>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        public static TAdapter GetAdapterStatic<TAdapter>(IAbstractFactory factory)
             where TAdapter : IAdapter, new()
        {
            return factory.CreateObject<object, TAdapter>(
                (_) =>
                {
                    var adapter = new TAdapter();

                    if (adapter is AdapterBase adapterBase)
                        adapterBase._factory = factory;

                    return adapter;
                },
                null);
        }
    }
}
