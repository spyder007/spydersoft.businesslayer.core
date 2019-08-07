// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="BusinessObjectSavedEventArgs.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.BusinessLayer.Core.Interfaces;

namespace spyderSoft.BusinessLayer.Core.Events
{
    /// <summary>
    /// Class BusinessObjectSavedEventArgs.
    /// </summary>
    public class BusinessObjectSavedEventArgs
    {
        /// <summary>
        /// Gets or sets the business object.
        /// </summary>
        /// <value>The business object.</value>
        public IBusinessObject BusinessObject { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectSavedEventArgs"/> class.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        public BusinessObjectSavedEventArgs(IBusinessObject businessObject)
        {
            BusinessObject = businessObject;
        }
    }
}