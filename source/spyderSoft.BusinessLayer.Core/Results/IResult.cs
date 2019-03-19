using System.Collections.Generic;

namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Interface for a Result returned from a data operation
    /// </summary>
    public interface IResult<TResult>
    {
        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        ResultType ResultType { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        List<IResultMessage> Messages { get; set; }

        /// <summary>
        /// Gets or sets the IsSuccessful.
        /// </summary>
        /// <value>
        /// The IsSuccessful.
        /// </value>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the Result.
        /// </summary>
        /// <value>
        /// The Result.
        /// </value>
        TResult Result { get; set; }
    }
}