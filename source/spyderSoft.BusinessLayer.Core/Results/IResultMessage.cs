// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IResultMessage.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// An interface to define messages to be returned
    /// </summary>
    public interface IResultMessage
    {
        /// <summary>
        /// Gets or Sets the Message to be displayed
        /// </summary>
        /// <value>The message.</value>
        string Message { get; set; }

        /// <summary>
        /// Gets or Sets a abbreviated version of the message
        /// </summary>
        /// <value>The short message.</value>
        string ShortMessage { get; set; }

        /// <summary>
        /// Gets or Sets the type of message
        /// </summary>
        /// <value>The type of the message.</value>
        ResultMessageType MessageType { get; set; }
    }
}
