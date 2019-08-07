// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IBusinessObjectFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.BusinessLayer.Core.Interfaces;
using spyderSoft.DataLayer.Core;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    /// <summary>
    /// Interface IBusinessObjectFactory
    /// </summary>
    public interface IBusinessObjectFactory
    {
        /// <summary>
        /// Gets the business object.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <typeparam name="TDataContract">The type of the t data contract.</typeparam>
        /// <param name="contract">The contract.</param>
        /// <returns>TBusinessObject.</returns>
        TBusinessObject GetBusinessObject<TBusinessObject, TDataContract>(TDataContract contract)
            where TBusinessObject : IBusinessObject<TDataContract>
            where TDataContract : IDataItem;
        /// <summary>
        /// Gets the new.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <returns>TBusinessObject.</returns>
        TBusinessObject GetNew<TBusinessObject>() where TBusinessObject : IBusinessObject;
        /// <summary>
        /// Injects the services.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        void InjectServices(IBusinessObject businessObject);
        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>TBusinessObject.</returns>
        TBusinessObject Load<TBusinessObject>(long id) where TBusinessObject : IBusinessObject;
        /// <summary>
        /// Loads the specified key.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>TBusinessObject.</returns>
        TBusinessObject Load<TBusinessObject>(string key) where TBusinessObject : IBusinessObject;
    }
}