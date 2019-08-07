// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IResult.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Interface for a Result returned from a data operation
    /// </summary>
    /// <typeparam name="TResult">The type of the t result.</typeparam>
    public interface IResult<TResult>
    {
        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>The type of the result.</value>
        ResultType ResultType { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        List<IResultMessage> Messages { get; set; }

        /// <summary>
        /// Gets or sets the IsSuccessful.
        /// </summary>
        /// <value>The IsSuccessful.</value>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the Result.
        /// </summary>
        /// <value>The Result.</value>
        TResult Result { get; set; }
    }
}