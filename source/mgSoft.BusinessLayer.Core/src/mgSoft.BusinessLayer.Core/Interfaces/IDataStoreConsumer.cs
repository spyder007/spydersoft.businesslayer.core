using mgSoft.DataLayer;
using mgSoft.DataLayer.Core;

namespace mgSoft.BusinessLayer.Core.Interfaces
{
    public interface IDataStoreConsumer
    {
        void SetDataStore(IDataStore dataStore);
    }
}