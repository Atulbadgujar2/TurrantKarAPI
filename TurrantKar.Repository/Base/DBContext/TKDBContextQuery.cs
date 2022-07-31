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

namespace TurrantKar.Repository
{

    /// <summary>  
    /// This class contains a session of core database and can be used to query and 
    /// save instances of core entities. It is a combination of the Unit Of Work and Repository patterns.  
    /// </summary>
    public partial class TKDBContext
    {
        #region DbQuery  
        #region Address
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

        #region CategoryViewDTO
        /// <summary>
        /// This is use to get CategoryViewDTO view data. Any linq queries against Microsoft.EntityFrameworkCore.DbQuery`1 
        /// is translated into database query.
        /// </summary>
        /// <remarks>
        /// All database queries to get Microsoft.EntityFrameworkCore.DbQuery`1 should contains all the columns corresponding 
        /// to properties of CategoryViewDTOQuery.
        /// </remarks>
        public DbQuery<CategoryViewDTO> CategoryViewDTOQuery
        {
            get; set;
        }
        #endregion

        #region CustomerView
        /// <summary>
        /// This is use to get CategoryViewDTO view data. Any linq queries against Microsoft.EntityFrameworkCore.DbQuery`1 
        /// is translated into database query.
        /// </summary>
        /// <remarks>
        /// All database queries to get Microsoft.EntityFrameworkCore.DbQuery`1 should contains all the columns corresponding 
        /// to properties of CustomerViewDTOQuery.
        /// </remarks>
        public DbQuery<CustomerViewDTO> CustomerViewDTOQuery
        {
            get; set;
        }
        #endregion

        #region ProductView
        /// <summary>
        /// This is use to get ProductViewDTO view data. Any linq queries against Microsoft.EntityFrameworkCore.DbQuery`1 
        /// is translated into database query.
        /// </summary>
        /// <remarks>
        /// All database queries to get Microsoft.EntityFrameworkCore.DbQuery`1 should contains all the columns corresponding 
        /// to properties of ProductViewDTOQuery.
        /// </remarks>
        public DbQuery<ProductViewDTO> ProductViewDTOQuery
        {
            get; set;
        }
        #endregion

        #endregion DbQuery



    }
}

