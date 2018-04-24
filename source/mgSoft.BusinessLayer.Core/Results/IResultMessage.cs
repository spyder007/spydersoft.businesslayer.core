namespace mgSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// An interface to define messages to be returned
    /// </summary>
    public interface IResultMessage
    {
        /// <summary>
        /// Gets or Sets the Message to be displayed
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or Sets a abbreviated version of the message
        /// </summary>
        string ShortMessage { get; set; }

        /// <summary>
        /// Gets or Sets the type of message
        /// </summary>
        ResultMessageType MessageType { get; set; }
    }
}
