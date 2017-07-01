using mgSoft.BusinessLayer.Core.Results;
using mgSoft.DataLayer.Core;
using System;
using System.Collections.Generic;

namespace mgSoft.BusinessLayer.Core.Interfaces
{
    /// <summary>
    /// Provides an interface to relate a data contract to the BO interface. 
    /// </summary>
    /// <typeparam name="TDataContract">The type of the data contract.</typeparam>
    public interface IBusinessObject<TDataContract> : IBusinessObject where TDataContract : IDataItem
    {
    }

    /// <summary>
    /// The Business Object interface
    /// </summary>
    /// TODO Edit XML Comment Template for IBusinessObject
    public interface IBusinessObject
    {
        #region BO Fields

        /// <summary>
        /// The data store to use with the business object
        /// </summary>
        IDataStore Store { get; set; }

        /// <summary>
        /// Gets the data contract identifier.
        /// </summary>
        /// <value>
        /// The data contract identifier.
        /// </value>
        long DataContractId { get; }

        string Key { get; }

        DateTimeOffset DateCreated { get; set; }

        DateTimeOffset DateUpdated { get; set; }

        string DisplayName { get; }

        #endregion BO Fields

        #region BO Lifecycle Contracts

        BusinessResult<IBusinessObject> Save();

        void Load(long id);

        void LoadByKey(string key);

        DeleteResults Delete();

        void SetIdFromKeyFields();

        void SetKeyFieldsFromId();

        #endregion BO Lifecycle Contracts
    }
}