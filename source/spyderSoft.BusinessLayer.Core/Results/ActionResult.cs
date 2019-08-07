// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="ActionResult.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Class ActionResult.
    /// Implements the <see cref="spyderSoft.BusinessLayer.Core.Results.IResultMessage" />
    /// </summary>
    /// <seealso cref="spyderSoft.BusinessLayer.Core.Results.IResultMessage" />
    public class ActionResult : IResultMessage
    {
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }
        /// <summary>
        /// Gets or Sets a abbreviated version of the message
        /// </summary>
        /// <value>The short message.</value>
        public string ShortMessage { get; set; }
        /// <summary>
        /// Gets or Sets the type of message
        /// </summary>
        /// <value>The type of the message.</value>
        public ResultMessageType MessageType { get; set; }
        /// <summary>
        /// Gets or Sets the Message to be displayed
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the result action.
        /// </summary>
        /// <value>The result action.</value>
        public ResultActionType ResultAction { get; set; }
    }
}
