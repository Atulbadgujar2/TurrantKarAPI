/* Copyright © 2021 ThinkAI (). All Rights Reserved.
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * 
 * Author: Atul Badgujar <atul.badgujar2@gmail.com>
 * Date: 25 Feb 2021
 * 
 * Contributor/s: 
 * Last Updated On: 25 Feb 2021
 */

namespace TurrantKar.Common
{
    /// <summary>
    /// This enum defines system fields in form of mask enum.
    /// </summary>
    [System.Flags]
    public enum SystemFieldMask {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,


        /// <summary>
        /// The identifier
        /// </summary>
        ID = 1,
        CREATED_BY = 2,
        CREATED_DATE = 4,
        MODIFIED_BY = 8,
        MODIFIED_DATE = 16,
        TENANT_ID = 32,
        IS_DELETED = 64,

        AddOpSystemFields = ID | CREATED_BY | CREATED_DATE | MODIFIED_BY | MODIFIED_DATE | TENANT_ID,
        UpdateOpSystemFields = MODIFIED_DATE | MODIFIED_BY,
        DeleteOpSystemFields = MODIFIED_DATE | MODIFIED_BY | IS_DELETED,

        All = ID | CREATED_BY | CREATED_DATE | MODIFIED_BY | MODIFIED_DATE | TENANT_ID | IS_DELETED

    }
}
