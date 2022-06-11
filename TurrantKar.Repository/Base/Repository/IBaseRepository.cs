/* Copyright © 2021 ThinkAI (). All Rights Reserved.
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * 
 * Author: Atul Badgujar <atul.badgujar2@gmail.com>
 * Date: 08 Feb 2021
 * 
 * Contributor/s: 
 * Last Updated On: 08 Feb 2021
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TK.Entity;
using TurrantKar.Common;

namespace TK.Data
{

    /// <summary>
    /// This interface provides generic methods to execute Get/Find/Add/Update/Delete query agianst respective entity type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of domain entity.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// Gets the count of all records of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>Returns all record count of type <typeparamref name="TEntity"/>.</returns>
        int CountAll();

        /// <summary>
        /// Count all entities in the database. Skip deleted items in the count.
        /// </summary>
        /// <param name="token">For cancellation</param>
        /// <returns>Number of entities in the database</returns>
        Task<int> CountAllAsync(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets TEntity that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier value to find TEntity.</param>
        /// <returns>Return TEntity that matches the specified identifier.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Get the entity given its primarky key, Guid id.
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <param name="token">For cancellation</param>
        /// <returns>Selected entity</returns>
        Task<TEntity> GetAsync(int id, CancellationToken token = default(CancellationToken));

        TEntity GetEntity(string sql, object[] parameters = null);

        /// <summary>
        /// Given the SQL query string, get the entity, which is 
        /// is materialized from the query result
        /// The result entity type is the same as the subclasses entity.
        /// </summary>
        /// <param name="sql">SQL query string</param>
        /// <param name="parameters">SQL query parameters, if any</param>
        /// <param name="token"></param>
        /// <returns>Resulting entity</returns>
        Task<TEntity> GetEntityAsync(string sql, object[] parameters = null, CancellationToken token = default(CancellationToken));

        V GetQueryEntity<V>(string sql, object[] parameters = null) where V : class;

        /// <summary>
        /// Asynchronously creates a entity (of type V) by executing input raw SQL query and parameters.
        /// </summary>
        /// <typeparam name="V">The type parameter (other than domain entity) to be map with raw sql result.</typeparam>
        /// <param name="sql">The raw SQL query to be execute to get required System.Collections.Generic.List`1.</param>
        /// <param name="parameters">The values to be assigned to parameters in input raw sql.</param>
        /// <param name="token">A token that can be use to propogate async operation cancel notification. Using this token async operation duration can be control.</param>
        /// <returns>Returns a task that represents the asynchronous operation. The task result contains a entity or null if no record found.</returns>
        Task<V> GetQueryEntityAsync<V>(string sql, object[] parameters = null, CancellationToken token = default(CancellationToken)) where V : class;

        TEntity Find(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Find the entity that matches the given expression. Deleted entities are skipped. 
        /// If there are more than one matches, raise an exception.
        /// </summary>
        /// <param name="match">Expression to match</param>
        /// <param name="token">For cancellation</param>
        /// <returns>Matched entity</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Find the entity that matches the given expression. Skip deleted entities optionally. 
        /// If there are more than one matches, raise an exception.
        /// </summary>
        /// <param name="match">Expression to match</param>
        /// <param name="skipDeleted">Whether to skip deleted entities</param>
        /// <param name="token">For cancellation</param>
        /// <returns>Matched entity</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, bool skipDeleted = true, CancellationToken token = default(CancellationToken));

        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Find all entities that match the given expression. Deleted entities are skipped.
        /// </summary>
        /// <param name="match">Expression to match</param>
        /// <param name="token">For cancellation</param>
        /// <returns>Matched entities</returns>
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Find all entities that match the given expression, optionally skipping deleted entities.
        /// </summary>
        /// <param name="match">Expression to match</param>
        /// <param name="skipDeleted">Whether to skip deleted entities</param>
        /// <param name="token">For cancellation</param>
        /// <returns>Matched entities</returns>
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, bool skipDeleted = true, CancellationToken token = default(CancellationToken));

        TEntity Add(TEntity t);

        /// <summary>
        /// Add a new entity. It is added to the entity set but not saved.
        /// </summary>
        /// <param name="t">Entity to add</param>
        /// <returns>Added entity</returns>
        Task<TEntity> AddAsync(TEntity t, CancellationToken token = default(CancellationToken));

        TEntity Update(TEntity t, object key);

        /// <summary>
        /// Update an existing entity. It first gets the EF tracked entity copy, and 
        /// then updates its property values. It does not save the entity.
        /// </summary>
        /// <param name="t">Entity to update</param>
        /// <param name="key">Entity primary key value</param>
        /// <param name="token">For cancellation</param>
        /// <returns>Updated entity</returns>
        Task<TEntity> UpdateAsync(TEntity t, object key, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete an entity. Notethat this not an async method.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="id">Entity Id to delete</param>
        /// <param name="token">For cancellation</param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken token = default(CancellationToken));

        void Save();

        /// <summary>
        /// Save all pending chnges
        /// </summary>
        /// <param name="token">For cancellation</param>
        /// <returns>Number of state changes made to the database</returns>
        Task<int> SaveAsync(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Updates system fields (ID, CreatedBy, CreatedOn, UpdatedBy and UpdatedOn) of all changed entities by accessing operations state (like Add, Modified etc.) tracked by current database context.
        /// </summary>
        /// <remarks>This method update system fields according to current state tracked by DbContext.</remarks>
        void UpdateEntitySystemFields();

        /// <summary>
        /// Updates all system field(s) (of entity) that are masked in provided includeOptions parameter.
        /// </summary>
        /// <param name="entity">The entity to update system field(s).</param>
        /// <param name="includeOptions">The mask value of SystemFieldMask enum that get updated.</param>
        void UpdateSystemFields(TEntity entity, SystemFieldMask includeOptions);

        /// <summary>
        /// Updates the system fields of entity as per provided operation type.
        /// </summary>
        /// <param name="entity">The entity to be update as per provided operation type.</param>
        /// <param name="opType">Type of the operation to get corresponding system fields to be update.</param>
        void UpdateSystemFieldMask(TEntity entity, OperationType opType);





        ///// <summary>
        ///// Releases unmanaged and - optionally - managed resources.
        ///// </summary>
        //void Dispose();

        bool PropertyChanged(Guid id, string propertyName);


        /// <summary>
        /// Get Orignal Values
        /// </summary>
        /// <typeparam name="PropType"></typeparam>
        /// <param name="id"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        PropType GetOrignalValue<PropType>(Guid id, string propertyName);


        /// <summary>
        /// Get All Record Except Delete 
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Get All Deleted Record
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> GetAllDeletedAsync();

        /// <summary>
        /// Gets the entity list based on input SQL and parameters.
        /// </summary>
        /// <param name="sql">A valid SQL string that should contains all properties of TEntity entity.</param>
        /// <param name="parameters">The list of sql parameters (if null none of sql parameters applied).</param>
        /// <returns>Returns entity list based on input SQL and parameters.</returns>
        List<TEntity> GetEntityList(string sql, object[] parameters);

        /// <summary>
        /// Asynchronously gets the entity list based on input SQL and parameters.
        /// </summary>
        /// <param name="sql">A valid SQL string that should contains all properties of TEntity entity.</param>
        /// <param name="parameters">The list of sql parameters (if null none of sql parameters applied).</param>
        /// <param name="token">A token that can be use to propogate async operation cancel notification. Using this token async operation duration can be control.</param>
        /// <returns>Returns entity list based on input SQL and parameters.</returns>
        Task<List<TEntity>> GetEntityListAsync(string sql, object[] parameters, CancellationToken token = default(CancellationToken));


        /// <summary>
        /// Gets the entity (of type V) list based on input SQL and parameters.
        /// </summary>
        /// <typeparam name="V">The type of entity of result.</typeparam>
        /// <param name="sql">A valid SQL string that should contains all properties of TEntity entity.</param>
        /// <param name="parameters">The list of sql parameters (if null none of sql parameters applied).</param>
        /// <returns>Returns entity (of type V) list based on input SQL and parameters.</returns>
        List<V> GetQueryEntityList<V>(string sql, object[] parameters) where V : class;

        /// <summary>
        /// Asynchronously gets the entity (of type V) list based on input SQL and parameters.
        /// </summary>
        /// <typeparam name="V">The type of entity of result.</typeparam>
        /// <param name="sql">A valid SQL string that should contains all properties of TEntity entity.</param>
        /// <param name="parameters">The list of sql parameters (if null none of sql parameters applied).</param>
        /// <param name="token">A token that can be use to propogate async operation cancel notification. Using this token async operation duration can be control.</param>
        /// <returns>Returns entity (of type V) list based on input SQL and parameters.</returns>
        Task<List<V>> GetQueryEntityListAsync<V>(string sql, object[] parameters, CancellationToken token = default(CancellationToken)) where V : class;

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteStoreProcedure(string sql, object[] parameters = null);





    }
}
