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
        public override string CREATED_BY
        {
            get; set;
        }

        [NotMapped]
        public override DateTime? CREATED_DATE
        {
            get; set;
        }

        [NotMapped]
        public override string MODIFIED_BY
        {
            get; set;
        }

        [NotMapped]
        public override DateTime? MODIFIED_DATE
        {
            get; set;
        }

        [NotMapped]
        public override bool IS_DELETED
        {
            get; set;
        }

        [NotMapped]
        public override int TENANT_ID
        {
            get; set;
        }


        [NotMapped]
        public override string ORACLE_REFERENCE_ID
        {
            get; set;
        }

        

    }
}
