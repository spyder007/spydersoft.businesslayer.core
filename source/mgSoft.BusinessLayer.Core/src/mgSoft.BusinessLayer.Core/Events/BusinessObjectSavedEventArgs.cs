using mgSoft.BusinessLayer.Core.Interfaces;

namespace mgSoft.BusinessLayer.Core.Events
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