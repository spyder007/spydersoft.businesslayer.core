// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IBusinessObject.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.BusinessLayer.Core.Results;
using spyderSoft.DataLayer.Core;
using System;
using System.Collections.Generic;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    /// <summary>
    /// Provides an interface to relate a data contract to the BO interface.
    /// Implements the <see cref="spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject" />
    /// </summary>
    /// <typeparam name="TDataContract">The type of the data contract.</typeparam>
    /// <seealso cref="spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject" />
    public interface IBusinessObject<TDataContract> : IBusinessObject where TDataContract : IDataItem
    {
    }

    /// <summary>
    /// The Business Object interface
    /// Implements the <see cref="spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject" />
    /// </summary>
    /// <seealso cref="spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObject" />
    public interface IBusinessObject
    {
        #region BO Fields

        /// <summary>
        /// The data store to use with the business object
        /// </summary>
        /// <value>The store.</value>
        IDataStore Store { get; set; }

        /// <summary>
        /// Gets the data contract identifier.
        /// </summary>
        /// <value>The data contract identifier.</value>
        long DataContractId { get; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        string Key { get; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>The date updated.</value>
        DateTimeOffset DateUpdated { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; }

        #endregion BO Fields

        #region BO Lifecycle Contracts

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>BusinessResult&lt;IBusinessObject&gt;.</returns>
        BusinessResult<IBusinessObject> Save();

        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Load(long id);

        /// <summary>
        /// Loads the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        void LoadByKey(string key);

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>DeleteResults.</returns>
        DeleteResults Delete();

        /// <summary>
        /// Sets the identifier from key fields.
        /// </summary>
        void SetIdFromKeyFields();

        /// <summary>
        /// Sets the key fields from identifier.
        /// </summary>
        void SetKeyFieldsFromId();

        #endregion BO Lifecycle Contracts
    }
}