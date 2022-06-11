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
        public virtual int ID
        {
            get; set;
        }


        public virtual DateTime? CREATED_DATE
        {
            get;
            set;
        }

        public virtual string CREATED_BY
        {
            get;
            set;
        }

        public virtual DateTime? MODIFIED_DATE
        {
            get;
            set;
        }

        public virtual string MODIFIED_BY
        {
            get;
            set;
        }

        public virtual bool IS_DELETED
        {
            get; set;
        }

        public virtual int TENANT_ID
        {
            get; set;
        }

        public virtual string ORACLE_REFERENCE_ID
        {
            get; set;
        }
        // Hari Dudani
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }   

}
