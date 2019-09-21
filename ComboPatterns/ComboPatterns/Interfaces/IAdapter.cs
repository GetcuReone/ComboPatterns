using System;
using System.Collections.Generic;
using System.Text;

namespace ComboPatterns.Interfaces
{
    /// <summary>
    /// Adapter interface
    /// </summary>
    public interface IAdapter
    {
        /// <summary>
        /// Adapter creation method
        /// </summary>
        /// <typeparam name="TAdapter">type of adapter created</typeparam>
        /// <returns>adapter <typeparamref name="TAdapter"/></returns>
        TAdapter GetAdapter<TAdapter>() where TAdapter : IAdapter, new();
    }
}
