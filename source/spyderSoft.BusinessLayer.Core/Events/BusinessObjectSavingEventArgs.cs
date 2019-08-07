// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="BusinessObjectSavingEventArgs.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using spyderSoft.BusinessLayer.Core.Interfaces;
using System;

namespace spyderSoft.BusinessLayer.Core.Events
{
    /// <summary>
    /// Class BusinessObjectSavingEventArgs.
    /// Implements the <see cref="spyderSoft.BusinessLayer.Core.Events.BusinessObjectSavedEventArgs" />
    /// </summary>
    /// <seealso cref="spyderSoft.BusinessLayer.Core.Events.BusinessObjectSavedEventArgs" />
    public class BusinessObjectSavingEventArgs : BusinessObjectSavedEventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BusinessObjectSavingEventArgs"/> is cancel.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessObjectSavingEventArgs"/> class.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        public BusinessObjectSavingEventArgs(IBusinessObject businessObject) : base(businessObject)
        {
            Cancel = false;
        }
    }
}