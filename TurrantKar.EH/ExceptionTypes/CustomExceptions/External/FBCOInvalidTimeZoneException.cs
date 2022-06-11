//===============================================================================
/* Copyright © 2021 ThinkAI (). All Rights Reserved.
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* Author: Atul Badgujar <atul.badgujar2@gmail.com>
* Date: 05 April 2021
* 
* Contributor/s: 
* Last Updated On: 05 April 2021*/
//===============================================================================

using System;
using System.Collections.Generic;

namespace TurrantKar.EH {

    /// <summary>
    /// It is a custom exception class inherited from base exception class.
    /// It is used to invalid time zone .
    /// </summary>
    [Serializable]
    public class TKInvalidTimeZoneException : TKRecoverableException {

        #region Local Members

        private static readonly string _message = "Timze zone is not valid.";

        #endregion Local Members

        #region Constructors

        /// <summary>
        /// Initialize constructor.
        /// </summary>
        public TKInvalidTimeZoneException()
            : base(_message, null) {
        }

        /// <summary>
        /// Initialize constructor with required parameter.
        /// </summary>
        /// <param name="message">Error message.</param>
        public TKInvalidTimeZoneException(string message)
            : base(message, null) {
        }

        /// <summary>
        /// Initialize constructor with required parameter.
        /// </summary>    
        /// <param name="message">Error message.</param>
        /// <param name="dataList">Validation data.</param>
        public TKInvalidTimeZoneException(string message, IList<TKErrorData> dataList)
            : base(message, null) {
            ErrorDataList = dataList;
        }


        /// <summary>
        /// Initialize constructor with required parameter.
        /// </summary>
        /// <param name="innerException">inner exception.</param>
        public TKInvalidTimeZoneException(Exception innerException)
            : base(_message, innerException) {
        }

        /// <summary>
        /// Initialize constructor with required parameter.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public TKInvalidTimeZoneException(string message, Exception innerException)
            : base(message, innerException) {
        }

        #endregion Constructors

        /// <summary>
        /// Gets the type of the TK error.
        /// </summary>
        /// <value>
        /// The type of the TK error.
        /// </value>
        public override ErrorType GetTKErrorType()
        {
          return ErrorType.InvalidTimeZone;
        }
    }
}
