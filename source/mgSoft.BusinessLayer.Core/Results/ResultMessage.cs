namespace mgSoft.BusinessLayer.Core.Results
{
    /// <inheritdoc />
    /// <summary>
    /// A validation or general message from trying to save.
    /// </summary>
    public class ResultMessage
        : IResultMessage
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultMessage"/> class.
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
        /// <param name="fieldId">The field identifier.</param>
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
        public string PropertyName { get; set; }

        #endregion Public Properties

        #region IResultMessage implementation
        /// <summary>
        /// The message to be shown
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// A short version of the message
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// The type of message
        /// </summary>
        public ResultMessageType MessageType { get; set; }

        #endregion IResultMessage implementation

        #region Overrides

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Message;
        }

        #endregion Overrides
    }
}