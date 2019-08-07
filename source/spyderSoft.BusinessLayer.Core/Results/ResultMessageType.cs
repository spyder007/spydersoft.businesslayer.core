// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="ResultMessageType.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// The type of the message or Severity
    /// </summary>
    public enum ResultMessageType
    {
        /// <summary>
        /// The information
        /// </summary>
        Information,
        /// <summary>
        /// The warning
        /// </summary>
        Warning,
        /// <summary>
        /// The error
        /// </summary>
        Error,
        /// <summary>
        /// The alert
        /// </summary>
        Alert,
        /// <summary>
        /// The cancel
        /// </summary>
        Cancel
    }
}