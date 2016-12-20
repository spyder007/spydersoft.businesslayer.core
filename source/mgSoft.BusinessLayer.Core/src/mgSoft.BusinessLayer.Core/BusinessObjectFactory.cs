using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mgSoft.BusinessLayer.Core.Interfaces;
using mgSoft.DataLayer;
using mgSoft.DataLayer.Core;

namespace mgSoft.BusinessLayer.Core
{
    /// <summary>
    /// Class BusinessObjectFactory.
    /// </summary>
    /// TODO Edit XML Comment Template for BusinessObjectFactory
    public class BusinessObjectFactory
    {
        /// <summary>
        /// The _data store
        /// </summary>
        /// TODO Edit XML Comment Template for _dataStore
        private IDataStore _dataStore;
        private IServiceInjector _injector;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectFactory"/> class.
        /// </summary>
        /// <param name="dataStore">The data store.</param>
        /// TODO Edit XML Comment Template for #ctor
        public BusinessObjectFactory(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectFactory"/> class.
        /// </summary>
        /// <param name="dataStore">The data store.</param>
        /// <param name="injector">The injector.</param>
        /// TODO Edit XML Comment Template for #ctor
        public BusinessObjectFactory(IDataStore dataStore, Interfaces.IServiceInjector injector) : this(dataStore)
        {
            _injector = injector;
        }

        /// <summary>
        /// Gets a new instance of a BusinessObject.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the BusinessObject.</typeparam>
        /// <returns>TBusinessObject.</returns>
        public TBusinessObject GetNew<TBusinessObject>() where TBusinessObject : Interfaces.IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            return businessObject;
        }

        /// <summary>
        /// Gets an instance of an existing BusinessObject with the specified ID.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the BusinessObject.</typeparam>
        /// <param name="id">The primary key (ID) of the object instance to be retrieved.</param>
        /// <returns>A BusinessObject.</returns>
        public TBusinessObject GetExisting<TBusinessObject>(long id) where TBusinessObject : Interfaces.IBusinessObject
        {
            TBusinessObject businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);
            businessObject.LoadByPrimaryKey(id);

            return businessObject;
        }

        /// <summary>
        /// Gets an instance of an existing BusinessObject with the specified external key.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the BusinessObject.</typeparam>
        /// <param name="key">The external key of the object instance to be retrieved.</param>
        /// <returns>A BusinessObject.</returns>
        public TBusinessObject GetExisting<TBusinessObject>(string key) where TBusinessObject : Interfaces.IBusinessObject
        {
            TBusinessObject businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);
            businessObject.LoadByExternalKey(key);

            return businessObject;
        }

        /// <summary>
        /// Gets an instance of an existing BusinessObject using the specified DataItem.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the BusinessObject.</typeparam>
        /// <param name="dataItem">The DataItem that represents the existing item.</param>
        /// <returns>A BusinessObject.</returns>
        public TBusinessObject GetExisting<TBusinessObject>(DataItem dataItem) where TBusinessObject : Interfaces.IBusinessObject
        {
            TBusinessObject businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject), dataItem);
            InjectServices(businessObject);

            return businessObject;
        }

        /// <summary>
        /// Gets a new instance of a BusinessObject.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
        /// <returns></returns>
        public TBusinessObject GetQuery<TBusinessObject>() where TBusinessObject : Interfaces.IBusinessObject
        {
            TBusinessObject businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            return businessObject;
        }

        #region Private Methods

        /// <summary>
        /// Check if the business object need to subscribe to any available services.
        /// </summary>
        /// <typeparam name="TBusinessObject">The type of the BusinessObject</typeparam>
        /// <param name="businessObject">The business object.</param>
        public void InjectServices<TBusinessObject>(TBusinessObject businessObject)
            where TBusinessObject : Interfaces.IBusinessObject
        {
            if (businessObject == null)
            {
                return;
            }

            if (businessObject is IDataStoreConsumer)
            {
                ((IDataStoreConsumer)businessObject).SetDataStore(_dataStore);
            }
            if (businessObject is IBusinessObjectFactoryConsumer)
            {
                ((IBusinessObjectFactoryConsumer)businessObject).SetBusinessObjectFactory(this);
            }

            if (_injector != null)
            {
                _injector.InjectServices(businessObject);
            }

        }

        #endregion
    }
}