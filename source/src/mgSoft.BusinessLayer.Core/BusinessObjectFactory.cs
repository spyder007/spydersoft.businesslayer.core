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
    public class BusinessObjectFactory
    {
        protected IDataStore Store { get; set; }

        public BusinessObjectFactory(IDataStore store)
        {
            Store = store;
        }

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
            var businessObject = (TBusinessObject) Activator.CreateInstance(typeof(TBusinessObject), contract);
            InjectServices(businessObject);
            businessObject.SetKeyFieldsFromId();
            return businessObject;
        }

        public void InjectServices(IBusinessObject businessObject)
        {
            var dsConsumer = businessObject as IDataStoreConsumer;
            dsConsumer?.SetDataStore(Store);
        }
    }
}
