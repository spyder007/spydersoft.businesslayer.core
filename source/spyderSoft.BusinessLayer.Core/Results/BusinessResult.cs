using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Creates a Result from a data operation for a Business Object.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    [DataContract]
    public class BusinessResult<TResult>
        : IResult<TResult>
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessResult{TResult}" /> class.
        /// </summary>
        public BusinessResult()
        {
            ResultType = Results.ResultType.Success;
            ResultAction = ResultActionType.None;
            Messages = new List<IResultMessage>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessResult{TResult}" /> class.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="message">The message.</param>
        public BusinessResult(ResultType resultType, ResultMessage message)
            : this()
        {
            ResultType = resultType;
            ResultAction = ResultActionType.None;
            Messages.Add(message);
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Gets or sets the result action.
        /// </summary>
        /// <value>
        /// The result action.
        /// </value>
        [DataMember]
        public ResultActionType ResultAction { get; set; }

        #endregion Public Properties

        #region IResult Implementation

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        [DataMember]
        public ResultType ResultType { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        [DataMember]
        public List<IResultMessage> Messages { get; set; }

        /// <summary>
        /// Gets or sets the IsSuccessful.
        /// </summary>
        /// <value>
        /// The IsSuccessful.
        /// </value>
        [DataMember]
        public bool IsSuccessful { get; set; }


        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        [DataMember]
        public TResult Result { get; set; }

        #endregion IResult Implementation

        #region Overrides

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return GetMessages();
        }

        #endregion Overrides

        #region Private Methods

        /// <summary>
        /// Loops through the messages list and builds it as a string.
        /// </summary>
        /// <returns>All the messages as a string with line feeds.</returns>
        private string GetMessages()
        {
            var sb = new StringBuilder();
            foreach (var message in Messages)
            {
                sb.AppendLine(message.Message);
            }
            return sb.ToString();
        }

        #endregion Private Methods
    }
}
