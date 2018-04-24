using mgSoft.BusinessLayer.Core.Interfaces;
using System;

namespace mgSoft.BusinessLayer.Core.Events
{
    public class BusinessObjectSavingEventArgs : BusinessObjectSavedEventArgs
    {
        public bool Cancel { get; set; }

        public BusinessObjectSavingEventArgs(IBusinessObject businessObject) : base(businessObject)
        {
            Cancel = false;
        }
    }
}