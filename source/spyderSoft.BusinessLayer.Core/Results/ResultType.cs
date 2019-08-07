// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="ResultType.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace spyderSoft.BusinessLayer.Core.Results
{
    /// <summary>
    /// Used to indicate the result of the save.
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// The success
        /// </summary>
        Success,
        /// <summary>
        /// The general failure
        /// </summary>
        GeneralFailure,
        /// <summary>
        /// The validation failure
        /// </summary>
        ValidationFailure
    }
}