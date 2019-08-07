// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="ExtensionMethods.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.BusinessLayer.Core.Attributes;
using spyderSoft.BusinessLayer.Core.Results;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace spyderSoft.BusinessLayer.Core
{
    /// <summary>
    /// Class ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Copies the properties to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="dest">The dest.</param>
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

        /// <summary>
        /// Determines whether [has halting messages] [the specified results].
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns><c>true</c> if [has halting messages] [the specified results]; otherwise, <c>false</c>.</returns>
        public static bool HasHaltingMessages(this IEnumerable<ActionResult> results)
        {
            return results.Any(r => r.MessageType == ResultMessageType.Error ||
                                    r.MessageType == ResultMessageType.Warning ||
                                    r.MessageType == ResultMessageType.Cancel);
        }
    }
}