// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IServiceInjector.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spyderSoft.BusinessLayer.Core.Interfaces
{
    /// <summary>
    /// Interface IServiceInjector
    /// </summary>
    public interface IServiceInjector
    {
        /// <summary>
        /// Injects the services.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        void InjectServices(IBusinessObject businessObject);
    }
}
