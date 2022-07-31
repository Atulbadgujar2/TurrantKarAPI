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


namespace TurrantKar.Repository
{

    public class TKDesignTimeDbContextFactory:BaseDesignTimeDbContextFactory<TKDBContext> {
    
        protected override TKDBContext CreateNewInstance(DbContextOptions<TKDBContext> options) {
            return new TKDBContext(options, _conString);
        }

    }
}
