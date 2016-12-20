using mgSoft.BusinessLayer.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgSoft.BusinessLayer.Core.Interfaces
{
    /// <summary>
    /// Interface IBusinessObject
    /// </summary>
    /// TODO Edit XML Comment Template for IBusinessObject
    public interface IBusinessObject
    {
        /// <summary>
        /// Loads the by primary key.
        /// </summary>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// TODO Edit XML Comment Template for LoadByPrimaryKey
        bool LoadByPrimaryKey(long primaryKey);
        /// <summary>
        /// Loads the by external key.
        /// </summary>
        /// <param name="externalKey">The external key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// TODO Edit XML Comment Template for LoadByExternalKey
        bool LoadByExternalKey(string externalKey);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// TODO Edit XML Comment Template for Save
        IEnumerable<ActionResult> Save();
    }
}
