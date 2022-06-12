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

namespace TK.Entity
{

    public interface ISystemEntityField
    {

        int Id
        {
            get; set;
        }

        DateTime CreatedOn
        {
            get; set;
        }

        int CreatedBy
        {
            get; set;
        }

        DateTime ModifiedOn
        {
            get; set;
        }

        int ModifiedBy
        {
            get; set;
        }

        int TenantId
        {
            get; set;
        }

        bool IsDeleted
        {
            get; set;
        }

    }

}
