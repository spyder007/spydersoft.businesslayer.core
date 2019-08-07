// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="LookupFieldAttribute.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spyderSoft.BusinessLayer.Core.Attributes
{
    /// <summary>
    /// Class LookupFieldAttribute.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class LookupFieldAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the type of the lookup.
        /// </summary>
        /// <value>The type of the lookup.</value>
        public Type LookupType { get; set; }
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupFieldAttribute" /> class.
        /// </summary>
        /// <param name="lookupType">Type of the lookup.</param>
        /// <param name="propertyName">Name of the property.</param>
        public LookupFieldAttribute(Type lookupType, string propertyName)
        {
            LookupType = lookupType;
            PropertyName = propertyName;
        }
    }
}
