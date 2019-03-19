using spyderSoft.BusinessLayer.Core.Interfaces;
using spyderSoft.DataLayer.Core;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    public interface IBusinessObjectFactory
    {
        TBusinessObject GetBusinessObject<TBusinessObject, TDataContract>(TDataContract contract)
            where TBusinessObject : IBusinessObject<TDataContract>
            where TDataContract : IDataItem;
        TBusinessObject GetNew<TBusinessObject>() where TBusinessObject : IBusinessObject;
        void InjectServices(IBusinessObject businessObject);
        TBusinessObject Load<TBusinessObject>(long id) where TBusinessObject : IBusinessObject;
        TBusinessObject Load<TBusinessObject>(string key) where TBusinessObject : IBusinessObject;
    }
}