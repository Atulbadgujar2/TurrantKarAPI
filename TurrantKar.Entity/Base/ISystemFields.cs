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

        int ID
        {
            get; set;
        }

        DateTime? CREATED_DATE
        {
            get; set;
        }

        string CREATED_BY
        {
            get; set;
        }

        string MODIFIED_BY
        {
            get; set;
        }

        DateTime? MODIFIED_DATE
        {
            get; set;
        }

        int TENANT_ID
        {
            get; set;
        }

        bool IS_DELETED
        {
            get; set;
        }

        string ORACLE_REFERENCE_ID
        {
            get;set;
        }
    }

}
