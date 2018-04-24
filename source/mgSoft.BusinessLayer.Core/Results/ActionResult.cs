using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgSoft.BusinessLayer.Core.Results
{
    public class ActionResult : IResultMessage
    {
        public Exception Exception { get; set; }
        public string ShortMessage { get; set; }
        public ResultMessageType MessageType { get; set; }
        public string Message { get; set; }
        public ResultActionType ResultAction { get; set; }
    }
}
