// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IDataStoreConsumer.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.DataLayer;
using spyderSoft.DataLayer.Core;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    /// <summary>
    /// Interface IDataStoreConsumer
    /// </summary>
    public interface IDataStoreConsumer
    {
        /// <summary>
        /// Sets the data store.
        /// </summary>
        /// <param name="dataStore">The data store.</param>
        void SetDataStore(IDataStore dataStore);
    }
}