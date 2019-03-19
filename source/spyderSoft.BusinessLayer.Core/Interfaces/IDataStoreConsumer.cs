using spyderSoft.DataLayer;
using spyderSoft.DataLayer.Core;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    public interface IDataStoreConsumer
    {
        void SetDataStore(IDataStore dataStore);
    }
}