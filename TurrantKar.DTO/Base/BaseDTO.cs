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
using System.ComponentModel.DataAnnotations.Schema;
using TK.Entity;

namespace TurrantKar.DTO
{

    public class BaseDTO : BaseEntity
    {        

        [NotMapped]
        public override int CreatedBy
        {
            get; set;
        }

        [NotMapped]
        public override DateTime CreatedOn
        {
            get; set;
        }

        [NotMapped]
        public override int ModifiedBy
        {
            get; set;
        }

        [NotMapped]
        public override DateTime ModifiedOn
        {
            get; set;
        }

        [NotMapped]
        public override bool IsDeleted
        {
            get; set;
        }

        [NotMapped]
        public override int TenantId
        {
            get; set;
        }


        

        

    }
}
