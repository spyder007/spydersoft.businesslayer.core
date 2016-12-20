using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgSoft.BusinessLayer.Core.Results
{
    public class ActionResult
    {
        public ActionResultType ResultType { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
