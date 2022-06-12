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
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TK.Entity
{

    public class BaseEntity : ISystemEntityField
    {
        
  
         [Key]
        public virtual int Id
        {
            get; set;
        }


        public virtual DateTime CreatedOn
        {
            get;
            set;
        }

        public virtual int CreatedBy
        {
            get;
            set;
        }

        public virtual DateTime ModifiedOn
        {
            get;
            set;
        }

        public virtual int ModifiedBy
        {
            get;
            set;
        }

        public virtual bool IsDeleted
        {
            get; set;
        }

        public virtual int TenantId
        {
            get; set;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }   

}
