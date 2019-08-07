// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="BusinessObjectFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.BusinessLayer.Core.Interfaces;
using spyderSoft.DataLayer.Core;
using System;

namespace spyderSoft.BusinessLayer.Core
{
    /// <summary>
    /// Class BusinessObjectFactory.
    /// Implements the <see cref="spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObjectFactory" />
    /// </summary>
    /// <seealso cref="spyderSoft.BusinessLayer.Core.Interfaces.IBusinessObjectFactory" />
    public class BusinessObjectFactory : IBusinessObjectFactory
    {
        #region Protected Properties

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        protected IDataStore Store { get; set; }
        /// <summary>
        /// Gets or sets the service injector.
        /// </summary>
        /// <value>The service injector.</value>
        protected IServiceInjector ServiceInjector { get; set; }

        #endregion Protected Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectFactory" /> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public BusinessObjectFactory(IDataStore store) : this(store, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectFactory" /> class.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="serviceInjector">The service injector.</param>
        public BusinessObjectFactory(IDataStore store, IServiceInjector serviceInjector)
        {
            Store = store;
            ServiceInjector = serviceInjector;
        }

        #endregion Constructors

        #region IBusinessObjectFactory Interface

        /// <summary>
        /// Gets the new.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <returns>TBusinessObject.</returns>
        public TBusinessObject GetNew<TBusinessObject>() where TBusinessObject : IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            return businessObject;
        }

        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>TBusinessObject.</returns>
        public TBusinessObject Load<TBusinessObject>(long id) where TBusinessObject : IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            businessObject.Load(id);
            return businessObject;
        }

        /// <summary>
        /// Loads the specified key.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>TBusinessObject.</returns>
        public TBusinessObject Load<TBusinessObject>(string key) where TBusinessObject : IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            businessObject.LoadByKey(key);
            return businessObject;
        }

        /// <summary>
        /// Gets the business object.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the t business object.</typeparam>
        /// <typeparam name="TDataContract">The type of the t data contract.</typeparam>
        /// <param name="contract">The contract.</param>
        /// <returns>TBusinessObject.</returns>
        public TBusinessObject GetBusinessObject<TBusinessObject, TDataContract>(TDataContract contract)
            where TBusinessObject : IBusinessObject<TDataContract>
            where TDataContract : IDataItem
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject), contract);
            InjectServices(businessObject);
            businessObject.SetKeyFieldsFromId();
            return businessObject;
        }

        /// <summary>
        /// Injects the services.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        public void InjectServices(IBusinessObject businessObject)
        {
            var dsConsumer = businessObject as IDataStoreConsumer;
            dsConsumer?.SetDataStore(Store);

            ServiceInjector?.InjectServices(businessObject);
        }

        #endregion IBusinessObjectFactory Interface
    }
}