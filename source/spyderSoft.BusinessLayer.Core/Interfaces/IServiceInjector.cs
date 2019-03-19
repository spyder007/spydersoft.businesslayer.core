using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    public interface IServiceInjector
    {
        void InjectServices(IBusinessObject businessObject);
    }
}
