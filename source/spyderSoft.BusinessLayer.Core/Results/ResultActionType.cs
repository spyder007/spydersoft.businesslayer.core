// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="ResultActionType.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Used to indicate a action needed after a save has been executed
    /// </summary>
    public enum ResultActionType
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The success
        /// </summary>
        Success,
        /// <summary>
        /// The error
        /// </summary>
        Error,
        /// <summary>
        /// The warning
        /// </summary>
        Warning,
        /// <summary>
        /// The prompt for action
        /// </summary>
        PromptForAction,
        /// <summary>
        /// The cancel
        /// </summary>
        Cancel
    }
}