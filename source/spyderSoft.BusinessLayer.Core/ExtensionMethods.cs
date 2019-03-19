using spyderSoft.BusinessLayer.Core.Attributes;
using spyderSoft.BusinessLayer.Core.Results;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace spyderSoft.BusinessLayer.Core
{
    public static class ExtensionMethods
    {
        public static void CopyPropertiesTo<T>(this T source, T dest)
        {
            var sourceProps = typeof(T).GetTypeInfo().DeclaredProperties.Where(x => x.CanRead && !x.GetCustomAttributes<SkipCopyAttribute>().Any()).ToList();
            var destProps = typeof(T).GetTypeInfo().DeclaredProperties.Where(x => x.CanWrite).ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }
            }
        }

        public static bool HasHaltingMessages(this IEnumerable<ActionResult> results)
        {
            return results.Any(r => r.MessageType == ResultMessageType.Error ||
                                    r.MessageType == ResultMessageType.Warning ||
                                    r.MessageType == ResultMessageType.Cancel);
        }
    }
}