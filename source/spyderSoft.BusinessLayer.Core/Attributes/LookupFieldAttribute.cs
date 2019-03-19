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
    /// TODO Edit XML Comment Template for LookupFieldAttribute
    public class LookupFieldAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the type of the lookup.
        /// </summary>
        /// <value>The type of the lookup.</value>
        /// TODO Edit XML Comment Template for LookupType
        public Type LookupType { get; set; }
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        /// TODO Edit XML Comment Template for PropertyName
        public string PropertyName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupFieldAttribute"/> class.
        /// </summary>
        /// <param name="lookupType">Type of the lookup.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// TODO Edit XML Comment Template for #ctor
        public LookupFieldAttribute(Type lookupType, string propertyName)
        {
            LookupType = lookupType;
            PropertyName = propertyName;
        }
    }
}
