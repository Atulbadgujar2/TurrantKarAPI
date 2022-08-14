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

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using TurrantKar.Common;
using TurrantKar.Entity;

namespace TurrantKar.Repository
{

    /// <summary>
    /// This is the base Repository class for all entities. It provides basic, common 
    /// database operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of the target entity.</typeparam>
    /// <typeparam name="U">The type of DbContext.</typeparam>
    /// <seealso cref="ewApps.Core.Data.IBaseRepository{TEntity}" />
    public class BaseRepository<TEntity, U> : IBaseRepository<TEntity> where TEntity : BaseEntity where U : DbContext
    {

        #region Local Members

        /// <summary>
        /// Instance of DbContext to execute sql query.
        /// </summary>
        protected U _context;
        IHttpContextAccessor _httpContextAccessor;
        //public ISession _session;
        private readonly string _identityAssignedId = "assignedId";



        #endregion Local Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity, U}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>

        public BaseRepository(U context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //_session = _httpContextAccessor.HttpContext.Session;
        }

        #endregion Constructor



        #region Get

        /// <inheritdoc />  
        public virtual TEntity Get(int id)
        {

            return _context.Set<TEntity>().Find(id);
        }

        /// <inheritdoc />  
        public virtual async Task<TEntity> GetAsync(int id, CancellationToken token = default(CancellationToken))
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }     


        #endregion Get

        #region Get All

        /// <inheritdoc />  
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }
        #endregion Get All

        #region Get All Async        
      
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
                return await _context.Set<TEntity>().Where(x => !x.IsDeleted).OrderByDescending(x => x.ModifiedOn).ToListAsync();           
            
        }

        public virtual async Task<ICollection<TEntity>> GetAllDeletedAsync()
        {
            return await _context.Set<TEntity>().Where(x => x.IsDeleted).ToListAsync();

        }
        #endregion

        #region Get All Async sp Call 

        /// <inheritdoc />  
        public TEntity GetEntity(string sql, object[] parameters = null)
        {
            if (parameters != null && parameters.Length > 0)
                return _context.Set<TEntity>().FromSql(sql, parameters).FirstOrDefault<TEntity>();
            else
            {
                return _context.Set<TEntity>().FromSql(sql).FirstOrDefault<TEntity>();
            }

        }
       

        /// <inheritdoc />  
        public async Task<TEntity> GetEntityAsync(string sql, object[] parameters = null, CancellationToken token = default(CancellationToken))
        {
            if (parameters != null && parameters.Length > 0)
                return await _context.Set<TEntity>().FromSql(sql, parameters).FirstOrDefaultAsync<TEntity>();
            else
            {
                return await _context.Set<TEntity>().FromSql(sql).FirstOrDefaultAsync<TEntity>();
            }
        }

        /// <inheritdoc />  
        public V GetQueryEntity<V>(string sql, object[] parameters = null) where V : class
        {
            if (parameters != null && parameters.Length > 0)
                return _context.Query<V>().FromSql(sql, parameters).FirstOrDefault<V>();
            else
            {
                return _context.Query<V>().FromSql(sql).FirstOrDefault<V>();
            }
        }

        /// <inheritdoc />  
        public async Task<V> GetQueryEntityAsync<V>(string sql, object[] parameters = null, CancellationToken token = default(CancellationToken)) where V : class
        {
            if (parameters != null && parameters.Length > 0)
                return await _context.Query<V>().FromSql(sql, parameters).FirstOrDefaultAsync<V>();
            else
            {
                return await _context.Query<V>().FromSql(sql).FirstOrDefaultAsync<V>();
            }
        }

        /// <inheritdoc />  
        public virtual List<TEntity> GetEntityList(string sql, object[] parameters)
        {
            IQueryable<TEntity> entityList;

            if (parameters != null && parameters.Length > 0)
                entityList = _context.Set<TEntity>().FromSql(sql, parameters);
            else
            {
                entityList = _context.Set<TEntity>().FromSql(sql);
            }

            return entityList.ToList();
        }

        /// <inheritdoc />  
        public virtual async Task<List<TEntity>> GetEntityListAsync(string sql, object[] parameters, CancellationToken token = default(CancellationToken))
        {
            IQueryable<TEntity> entityList;

            if (parameters != null && parameters.Length > 0)
                entityList = _context.Query<TEntity>().FromSql(sql, parameters);
            else
            {
                entityList = _context.Query<TEntity>().FromSql(sql);
            }

            return await entityList.ToListAsync();
        }


        /// <inheritdoc />  
        public List<V> GetQueryEntityList<V>(string sql, object[] parameters) where V : class
        {
            IQueryable<V> querable;

            if (parameters != null && parameters.Length > 0)
            {
                querable = _context.Query<V>().FromSql(sql, parameters);
            }
            else
            {
                querable = _context.Query<V>().FromSql(sql);
            }

            return querable.ToList();
        }

        /// <inheritdoc />  
        public async Task<List<V>> GetQueryEntityListAsync<V>(string sql, object[] parameters, CancellationToken token = default(CancellationToken)) where V : class
        {
            IQueryable<V> querable;

            if (parameters != null && parameters.Length > 0)
            {
                querable = _context.Query<V>().FromSql(sql, parameters);
            }
            else
            {
                querable = _context.Query<V>().FromSql(sql);
            }

            return await querable.ToListAsync();
        }

        #endregion

        #region Count

        /// <inheritdoc />  
        public int CountAll()
        {
            return _context.Set<TEntity>().Count();
        }

        /// <inheritdoc />  
        public async Task<int> CountAllAsync(CancellationToken token = default(CancellationToken))
        {
            //return await _context.Set<TEntity>().Where(x => !x.Deleted).CountAsync();
            return await _context.Set<TEntity>().CountAsync();

        }

        #endregion Count

        #region Find

        /// <inheritdoc />  
        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _context.Set<TEntity>().SingleOrDefault(match);
        }

        /// <inheritdoc />  
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken token = default(CancellationToken))
        {
            return await FindAsync(match, true);
        }

        /// <inheritdoc />  
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, bool skipDeleted = true, CancellationToken token = default(CancellationToken))
        {
            //if(skipDeleted)
            //  return await _context.Set<T>().Where(x => !x.Deleted).SingleOrDefaultAsync(match);
            //else
            //  return await _context.Set<T>().SingleOrDefaultAsync(match);

            return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        /// <inheritdoc />  
        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _context.Set<TEntity>().Where(match).ToList();
        }

        /// <inheritdoc />  
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken token = default(CancellationToken))
        {
            return await FindAllAsync(match, true);
        }

        /// <inheritdoc />  
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, bool skipDeleted = true, CancellationToken token = default(CancellationToken))
        {
            //if(skipDeleted)
            //  return await _context.Set<TEntity>().Where(match).Where(x => !x.Deleted).ToListAsync();
            //else
            //  return await _context.Set<TEntity>().Where(match).ToListAsync();

            return await _context.Set<TEntity>().Where(match).ToListAsync();
        }

        #endregion Find

        #region Add

        /// <inheritdoc />  
        public virtual TEntity Add(TEntity t)
        {
            _context.Set<TEntity>().Add(t);
            return t;
        }

        /// <inheritdoc />  
        public virtual async Task<TEntity> AddAsync(TEntity t, CancellationToken token = default(CancellationToken))
        {
            await _context.Set<TEntity>().AddAsync(t);
            return t;
        }

        #endregion Add

        #region Update

        /// <inheritdoc />  
        public virtual TEntity Update(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = _context.Set<TEntity>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }

        /// <inheritdoc />  
        public virtual async Task<TEntity> UpdateAsync(TEntity t, object key, CancellationToken token = default(CancellationToken))
        {
            if (t == null)
                return null;
            TEntity exist = await _context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }

        #endregion Update

        #region Delete

        /// <inheritdoc />  
        public virtual async Task DeleteAsync(int id, CancellationToken token = default(CancellationToken))
        {
            // Get the entity
            TEntity e = await GetAsync(id);
            // Call Delete
            Delete(e);
        }


        /// <inheritdoc />  
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            //_context.SaveChanges();
        }


        #endregion Delete

        #region Save

        /// <inheritdoc />  
        public virtual void Save()
        {
            _context.SaveChanges();
        }

        /// <inheritdoc />  
        public async virtual Task<int> SaveAsync(CancellationToken token = default(CancellationToken))
        {
            return await _context.SaveChangesAsync();
        }

        #endregion Save

        #region SP

        /// <inheritdoc />  
        public int ExecuteStoreProcedure(string sql, object[] parameters = null)
        {
            if (parameters != null && parameters.Length > 0)
                return  _context.Database.ExecuteSqlCommand(sql, parameters);
            else
            {
                return _context.Database.ExecuteSqlCommand(sql);
            }

        }
        #endregion

        #region System Field 

        /// <inheritdoc />  
        public void UpdateEntitySystemFields()
        {
            // Get list of all entities that are either Add or Modified or Deleted from current dbcontext.
            List<EntityEntry> trackedEntityEntryList = _context.ChangeTracker.Entries()
                                                       .Where(trackedEntity => (trackedEntity.State == EntityState.Added ||
                                                       trackedEntity.State == EntityState.Modified || trackedEntity.State == EntityState.Deleted))
                                                       .ToList();

            // Loop on all changed entity list to update system fields as per current entity state.
            for (int i = 0; i < trackedEntityEntryList.Count; i++)
            {
                // Check whether changed entity implemented ISystemEntityField interface. If yes, make a call to update system fields in entity.
                if (trackedEntityEntryList[i] is ISystemEntityField sysEntityFields)
                {
                    // If entity state is Added, make a call to update all system fields that are defined (in SystemFieldMask.AddOpSystemFields enum) to be update in any Add operation.
                    if (trackedEntityEntryList[i].State == EntityState.Added)
                    {
                        UpdateSystemFields(trackedEntityEntryList[i].Entity as TEntity, SystemFieldMask.AddOpSystemFields);
                    }
                    // If entity state is Modified, make a call to update all system fields that are defined (in SystemFieldMask.UpdateOpSystemFields enum) to be update in any Add operation.
                    else if (trackedEntityEntryList[i].State == EntityState.Modified)
                    {
                        UpdateSystemFields(trackedEntityEntryList[i].Entity as TEntity, SystemFieldMask.UpdateOpSystemFields);
                    }
                    // If entity state is Deleted, make a call to update all system fields that are defined (in SystemFieldMask.DeleteOpSystemFields enum) to be update in any Add operation.
                    else if (trackedEntityEntryList[i].State == EntityState.Deleted)
                    {
                        UpdateSystemFields(trackedEntityEntryList[i].Entity as TEntity, SystemFieldMask.DeleteOpSystemFields);
                    }
                }
            }
        }

        /// <inheritdoc />  
        public virtual void UpdateSystemFields(TEntity entity, SystemFieldMask includeOptions)
        {
            // Gets current user session.
            //UserSession session = _sessionManager.GetSession();

            // Check whether entity is derived from ISystemEntityField interface.
            if (entity is ISystemEntityField sysEntityFields)
            {
                //Not Required because we are generating auto identity number into database 
                //// If input masked value contain SystemFieldMask.Id, generate new value for ID system field. 
                //if (includeOptions.HasFlag(SystemFieldMask.ID))
                //{
                //    sysEntityFields.ID = Guid.NewGuid();
                //}

                // If input masked value contain SystemFieldMask.CreatedBy, updates CreatedBy with current login user from session. 
                if (includeOptions.HasFlag(SystemFieldMask.CREATED_BY))
                {
                    //sysEntityFields.CREATED_BY = TKConstant.TENANT_USER_ID.ToString();
                    //sysEntityFields.CreatedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Headers[_identityAssignedId]);
                    sysEntityFields.CreatedBy = 1;
                    //sysEntityFields.CREATED_BY = _session.GetString("CurrentIdentityUser");

                }

                // If input masked value contain SystemFieldMask.CreatedOn, updates CreatedOn with current UTC date and time.
                if (includeOptions.HasFlag(SystemFieldMask.CREATED_DATE))
                {
                    sysEntityFields.CreatedOn = DateTime.UtcNow;
                }

                // If input masked value contain SystemFieldMask.UpdatedBy, updates UpdatedBy with current login user from session. 
                if (includeOptions.HasFlag(SystemFieldMask.MODIFIED_BY))
                {
                    //sysEntityFields.MODIFIED_BY = TKConstant.TENANT_USER_ID.ToString();
                    //sysEntityFields.ModifiedBy = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Headers[_identityAssignedId]);
                    sysEntityFields.ModifiedBy = 1;
                    //string ab = _httpContextAccessor.HttpContext.Request.Cookies["IdentityUser"];
                    //sysEntityFields.MODIFIED_BY = _session.GetString("CurrentIdentityUser");
                    //sysEntityFields.MODIFIED_BY = _httpContextAccessor.HttpContext.Request.Cookies["IdentityUser"];

                }

                // If input masked value contain SystemFieldMask.UpdatedOn, updates UpdatedOn with current UTC date and time.
                if (includeOptions.HasFlag(SystemFieldMask.MODIFIED_DATE))
                {
                    sysEntityFields.ModifiedOn = DateTime.UtcNow;
                }

                // If input masked value contain SystemFieldMask.UpdatedOn, updates UpdatedOn with current UTC date and time.
                if (includeOptions.HasFlag(SystemFieldMask.TENANT_ID))
                {
                    sysEntityFields.TenantId = TKConstant.TenantId;
                }

                // If input masked value contain SystemFieldMask.UpdatedOn, updates UpdatedOn with current UTC date and time.
                if (includeOptions.HasFlag(SystemFieldMask.IS_DELETED))
                {
                    sysEntityFields.IsDeleted = true;
                }
            }
        }

        /// <inheritdoc />  
        public virtual void UpdateSystemFieldMask(TEntity entity, OperationType opType)
        {

            // Check whether entity is derived from ISystemEntityField interface.
            if (entity is ISystemEntityField)
            {
                // Gets system field mask value that are defined corresponding to input operation type.
                SystemFieldMask systemFieldBitMaskValue = GenerateSystemFieldMaskValue(opType);

                // Updates all system fields (masked in systemFieldBitMaskValue) of entity. 
                UpdateSystemFields(entity, systemFieldBitMaskValue);
            }
        }

        // This method returns system field mask value defined as updatable for passed operation type.
        private SystemFieldMask GenerateSystemFieldMaskValue(OperationType opType)
        {
            SystemFieldMask systemFieldBitMaskValue = SystemFieldMask.None;
            switch (opType)
            {
                case OperationType.Add:
                    systemFieldBitMaskValue = SystemFieldMask.AddOpSystemFields;
                    break;
                case OperationType.Update:
                    systemFieldBitMaskValue = SystemFieldMask.UpdateOpSystemFields;
                    break;
                case OperationType.Delete:
                    systemFieldBitMaskValue = SystemFieldMask.DeleteOpSystemFields;
                    break;
                    //default:
                    //    throw new EwpInvalidOperationException("Invalid operation type.");
            }

            return systemFieldBitMaskValue;
        }

        #endregion System Filed



        public bool PropertyChanged(Guid id, string propertyName)
        {
            EntityEntry entityEntry = _context.ChangeTracker.Entries().FirstOrDefault(i => i.Entity.GetType().Name == typeof(TEntity).Name && Guid.Parse(i.OriginalValues["ID"].ToString()).Equals(id));

            if (entityEntry != null)
            {
                return entityEntry.OriginalValues[propertyName] != entityEntry.CurrentValues[propertyName];
            }
            else
            {
                return false;
            }
        }

        public PropType GetOrignalValue<PropType>(Guid id, string propertyName)
        {
            EntityEntry entityEntry = _context.ChangeTracker.Entries().FirstOrDefault(i => i.Entity.GetType().Name == typeof(TEntity).Name && Guid.Parse(i.OriginalValues["ID"].ToString()).Equals(id));

            if (entityEntry != null)
            {
                return (PropType)entityEntry.OriginalValues[propertyName];
            }
            else
            {
                return default(PropType);
            }
        }

      



    }
}
