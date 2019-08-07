// ***********************************************************************
// Assembly         : spyderSoft.BusinessLayer.Core
// Author           : matt
// Created          : 08-07-2019
//
// Last Modified By : matt
// Last Modified On : 08-07-2019
// ***********************************************************************
// <copyright file="IBusinessObjectFactoryConsumer.cs" company="">
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
    /// Interface IBusinessObjectFactoryConsumer
    /// </summary>
    public interface IBusinessObjectFactoryConsumer
    {
        /// <summary>
        /// Sets the business object factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        void SetBusinessObjectFactory(BusinessObjectFactory factory);
    }
}
