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
using System.Net;

namespace TurrantKar.EH {
    /// <summary>
    /// This is custom exception raised on Service call.
    /// </summary>
    /// <seealso cref="TurrantKar.EH.BaseException" />
    public class TKServiceException:BaseException {

        private string _message = "";
        private HttpStatusCode _statusCode;
        private ErrorType _errorType;



        /// <summary>
        /// Initializes a new instance of the <see cref="TKServiceException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="errorDataList">The TK error data list.</param>
        public TKServiceException(string message, HttpStatusCode statusCode, ErrorType errorType, IList<TKErrorData> errorDataList) : base(message) {
            _message = message;
            _statusCode = statusCode;
            ErrorDataList = errorDataList;
            _errorType = errorType;
        }

        /// <summary>
        ///  The type of the TK error.
        /// </summary>
        /// <returns>Returns ErrorType mapped to <see cref="TKServiceException"/>.</returns>
        public override ErrorType GetTKErrorType() {
            //return ErrorType.ServiceProcessException;
            return _errorType;
        }
    }
}
