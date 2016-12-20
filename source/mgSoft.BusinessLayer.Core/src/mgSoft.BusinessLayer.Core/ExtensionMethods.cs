using mgSoft.BusinessLayer.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgSoft.BusinessLayer.Core
{
    public static class ExtensionMethods
    {
        public static bool HasHaltingMessages(this IEnumerable<ActionResult> results)
        {
            return results.Any(r => r.ResultType == ActionResultType.CANCEL ||
                                    r.ResultType == ActionResultType.ERROR ||
                                    r.ResultType == ActionResultType.WARNING);
        }
    }
}
