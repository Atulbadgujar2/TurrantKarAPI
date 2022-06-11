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

namespace TurrantKar.EH
{

    /// <summary>
    /// It is a custom exception class inherited to base exception. It is use for Invalid Version Exception.
    /// </summary>
    public class TKInvalidVersionException : BaseException
    {

        #region Local Members

        private static readonly string _message = "Invalid Version Exception.";

        #endregion Local Members

        #region Constructor

        /// <inheritdoc />
        public TKInvalidVersionException()
            : base(_message, null)
        {
        }

        /// <inheritdoc />
        public TKInvalidVersionException(string message)
            : base(message, null)
        {
        }


        /// <inheritdoc />
        public TKInvalidVersionException(Exception innerException)
            : base(_message, innerException)
        {
        }

        /// <inheritdoc />
        public TKInvalidVersionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Constructor

        
        /// <summary>
        /// Gets the type of the TK error.
        /// </summary>
        /// <returns></returns>
        /// <value>
        /// The type of the TK error.
        /// </value>
        public override ErrorType GetTKErrorType()
        {
            return ErrorType.InvalidVersion;
        }
    }
}
