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

using System;
using System.Threading.Tasks;
using System.Transactions;

namespace TurrantKar.Data
{

    /// <summary>
    /// This class provides methods save enitty 
    /// </summary>
    /// <seealso cref="TurrantKar.Data.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {

        #region Local Members

        private readonly TKDBContext _TKDBContext;
        private bool _disableSaveChanges = false;


        #endregion Local Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="coreDbContext">The core database context.</param>
        /// <param name="disableSaveChanges">if set to <c>true</c> [disable save changes].</param>
        public UnitOfWork(TKDBContext TKDBContext, bool disableSaveChanges = false)
        {
            _TKDBContext = TKDBContext;
            _disableSaveChanges = disableSaveChanges;
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            if (_disableSaveChanges == false)
            {
                _TKDBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            if (_disableSaveChanges == false)
            {
                await _TKDBContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Saves all instances.
        /// </summary>
        /// <param name="enableSaveChnages">if set to <c>true</c> [enable save chnages].</param>
        public void SaveAll(bool enableSaveChnages = false)
        {

            if (_disableSaveChanges == false || enableSaveChnages == true)
            {

                using (var txscope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        _TKDBContext.SaveChanges();

                        txscope.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }

        #endregion Public Methods

    }
}
