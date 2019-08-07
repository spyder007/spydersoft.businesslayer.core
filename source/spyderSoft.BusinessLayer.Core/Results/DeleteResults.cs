// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="DeleteResults.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Text;

namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Results from a Delete
    /// </summary>
    public class DeleteResults
    {
        #region Private Variables

        /// <summary>
        /// The messages
        /// </summary>
        private List<string> _messages;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteResults" /> class.
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
        /// <value>The messages.</value>
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
        /// <value><c>true</c> if this instance is successful; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <returns>System.String.</returns>
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
