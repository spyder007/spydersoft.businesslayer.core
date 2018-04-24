using System.Collections.Generic;
using System.Text;

namespace mgSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Results from a Delete
    /// </summary>
    public class DeleteResults
    {
        #region Private Variables

        private List<string> _messages;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteResults"/> class.
        /// </summary>
        public DeleteResults()
        {
            _messages = new List<string>();
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Messages as a string - Read Only
        /// </summary>
        public string Messages
        {
            get
            {
                return GetMessages();
            }
        }

        /// <summary>
        /// Indicated is the delete succeeded.  Read Only
        /// </summary>
        public bool IsSuccessful
        {
            get
            {
                return (_messages.Count == 0);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a message to the delete results
        /// </summary>
        /// <param name="message">The message</param>
        public void AddMessage(string message)
        {
            _messages.Add(message);
        }

        #endregion

        #region Private Methods

        private string GetMessages()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var message in _messages)
            {
                sb.AppendLine(message);
            }
            return sb.ToString();
        }

        #endregion
    }
}
