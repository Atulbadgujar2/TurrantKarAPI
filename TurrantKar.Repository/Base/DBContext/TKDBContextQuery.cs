/* Copyright © 2021 ThinkAI (). All Rights Reserved.
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * 
 * Author: Atul Badgujar <atul.badgujar2@gmail.com>
 * Date: 25 Feb 2021
 * 
 * Contributor/s: 
 * Last Updated On: 25 Feb 2021
 */

using Microsoft.EntityFrameworkCore;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TK.Data
{

    /// <summary>  
    /// This class contains a session of core database and can be used to query and 
    /// save instances of core entities. It is a combination of the Unit Of Work and Repository patterns.  
    /// </summary>
    public partial class TKDBContext
    {
        #region DbQuery  
        #region Empty
        /// <summary>
        /// This is use to get AddressDTO view data. Any linq queries against Microsoft.EntityFrameworkCore.DbQuery`1 
        /// is translated into database query.
        /// </summary>
        /// <remarks>
        /// All database queries to get Microsoft.EntityFrameworkCore.DbQuery`1 should contains all the columns corresponding 
        /// to properties of AddressQuery.
        /// </remarks>
        public DbQuery<AddressDTO> AddressQuery
        {
            get; set;
        }
        #endregion


        #endregion DbQuery


        
    }
}

