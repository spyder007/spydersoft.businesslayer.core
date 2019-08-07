// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="ResultMessage.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// A validation or general message from trying to save.
    /// Implements the <see cref="spyderSoft.BusinessLayer.Core.Results.IResultMessage" />
    /// </summary>
    /// <seealso cref="spyderSoft.BusinessLayer.Core.Results.IResultMessage" />
    /// <inheritdoc />
    public class ResultMessage
        : IResultMessage
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMessage" /> class.
        /// </summary>
        public ResultMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMessage" /> class.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="message">The message.</param>
        public ResultMessage(ResultMessageType messageType, string shortMessage, string message)
        {
            MessageType = messageType;
            ShortMessage = shortMessage;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMessage" /> class.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="message">The message.</param>
        /// <param name="propertyName">Name of the property.</param>
        public ResultMessage(ResultMessageType messageType,
                             string shortMessage,
                             string message,
                             string propertyName)
            : this(messageType, shortMessage, message)
        {
            PropertyName = propertyName;
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// The property name of the field in error, if any.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName { get; set; }

        #endregion Public Properties

        #region IResultMessage implementation
        /// <summary>
        /// The message to be shown
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// A short version of the message
        /// </summary>
        /// <value>The short message.</value>
        public string ShortMessage { get; set; }

        /// <summary>
        /// The type of message
        /// </summary>
        /// <value>The type of the message.</value>
        public ResultMessageType MessageType { get; set; }

        #endregion IResultMessage implementation

        #region Overrides

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Message;
        }

        #endregion Overrides
    }
}