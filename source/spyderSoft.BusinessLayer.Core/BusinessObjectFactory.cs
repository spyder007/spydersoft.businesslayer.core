using spyderSoft.BusinessLayer.Core.Interfaces;
using spyderSoft.DataLayer.Core;
using System;

namespace spyderSoft.BusinessLayer.Core
{
    public class BusinessObjectFactory : IBusinessObjectFactory
    {
        #region Protected Properties

        protected IDataStore Store { get; set; }
        protected IServiceInjector ServiceInjector { get; set; }

        #endregion Protected Properties

        #region Constructors

        public BusinessObjectFactory(IDataStore store) : this(store, null)
        {
        }

        public BusinessObjectFactory(IDataStore store, IServiceInjector serviceInjector)
        {
            Store = store;
            ServiceInjector = serviceInjector;
        }

        #endregion Constructors

        #region IBusinessObjectFactory Interface

        public TBusinessObject GetNew<TBusinessObject>() where TBusinessObject : IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            return businessObject;
        }

        public TBusinessObject Load<TBusinessObject>(long id) where TBusinessObject : IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            businessObject.Load(id);
            return businessObject;
        }

        public TBusinessObject Load<TBusinessObject>(string key) where TBusinessObject : IBusinessObject
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject));
            InjectServices(businessObject);

            businessObject.LoadByKey(key);
            return businessObject;
        }

        public TBusinessObject GetBusinessObject<TBusinessObject, TDataContract>(TDataContract contract)
            where TBusinessObject : IBusinessObject<TDataContract>
            where TDataContract : IDataItem
        {
            var businessObject = (TBusinessObject)Activator.CreateInstance(typeof(TBusinessObject), contract);
            InjectServices(businessObject);
            businessObject.SetKeyFieldsFromId();
            return businessObject;
        }

        public void InjectServices(IBusinessObject businessObject)
        {
            var dsConsumer = businessObject as IDataStoreConsumer;
            dsConsumer?.SetDataStore(Store);

            ServiceInjector?.InjectServices(businessObject);
        }

        #endregion IBusinessObjectFactory Interface
    }
}