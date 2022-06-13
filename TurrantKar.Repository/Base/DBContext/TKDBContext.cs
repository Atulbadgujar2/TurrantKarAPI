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

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using TurrantKar.Common;
using TurrantKar.DTO;
using TurrantKar.Entity;

namespace TK.Data
{

    /// <summary>  
    /// This class contains a session of core database and can be used to query and 
    /// save instances of core entities. It is a combination of the Unit Of Work and Repository patterns.  
    /// </summary>
    public partial class TKDBContext : DbContext
    {

        #region Local Members

        protected string _connString;
        //protected IConnectionManager _connectionManager;

        #endregion Local Members

        #region Constructor

        /// <summary>
        /// Default constructor to initialize member variables (if any).
        /// </summary>       
        public TKDBContext()       
        {
            
        }

        /// <summary>
        /// Default constructor to initialize member variables (if any).
        /// </summary>
        /// <param name="options">The DbContextOptions instance carries configuration information such as: 
        /// (a) The database provider to use, UseSqlServer or UseSqlite
        /// (b) Connection string or identifier of the database instance    
        /// </param>
        /// <param name="connString">The Core database connection string.</param>
        public TKDBContext(DbContextOptions<TKDBContext> options, string connString) : base(options)
        {
            _connString = connString;
        }


        /// <summary>
        /// Constructor to initialize member variables (if any).
        /// </summary>
        /// <param name="options">The DbContextOptions instance carries configuration information such as: 
        /// (a) The database provider to use, UseSqlServer or UseSqlite
        /// (b) Connection string or identifier of the database instance    
        /// </param>
        /// <param name="appSetting">Instance of Appsettings object that contains core database 
        /// connection string.
        /// </param>
        public TKDBContext(DbContextOptions<TKDBContext> options, IOptions<ConnectionStrings> appSetting) : base(options)
        {
            _connString = appSetting.Value.SqlConnection;
            // _connectionManager = connectionManager;
        }

        #endregion Constructor

        #region DbContext Override Methods

        /// <inheritdoc />  
        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Default Value Section

            #endregion

            base.OnModelCreating(builder);
        }


        /// <inheritdoc />  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings"))
             .AddJsonFile($"appsettings.dev.json", false, true);

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        #endregion DbContext Override Methods

    

        #region DbSet

        #region Address
        /// <summary>
        /// DbSet&lt;Favorite&gt; can be used to query and save instances of Favorite entity. 
        /// Linq queries can written using DbSet&lt;Favorite&gt; that will be translated to sql query and executed against database EMPLOYEE_DATA table. 
        /// </summary>
        public DbSet<Address> Address { get; set; }
        #endregion



        #endregion DbSet

    
    }


}
