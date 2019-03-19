using spyderSoft.BusinessLayer.Core.Interfaces;

namespace spyderSoft.BusinessLayer.Core.Events
{
    public class BusinessObjectSavedEventArgs
    {
        public IBusinessObject BusinessObject { get; set; }

        public BusinessObjectSavedEventArgs(IBusinessObject businessObject)
        {
            BusinessObject = businessObject;
        }
    }
}