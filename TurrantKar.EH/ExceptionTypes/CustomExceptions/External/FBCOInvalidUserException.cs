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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Runtime.Serialization;

//namespace TurrantKar.EH {


//  /// <summary>
//  /// It is a custom exception class inherited to base exception. It is use for invalid user.
//  /// </summary>
//  [Serializable]
//  public class TKInvalidUserException : TKRecoverableException {

//    #region Local Members

//    private static readonly string _message = "The given user id is invalid.";

//    #endregion Local Members

//    #region Constructor

//    /// <inheritdoc />
//    public TKInvalidUserException()
//      : base(_message, null) {
//    }

//    /// <summary>
//    /// Initializes constructor with required parameter.
//    /// </summary>
//    /// <param name="message">Concurrency message.</param>
//    public TKInvalidUserException(string message)
//      : base(message, null) {
//    }

//    /// <summary>
//    /// Initializes constructor with required parameter.
//    /// </summary>
//    /// <param name="innerException">Inner exception.</param>
//    public TKInvalidUserException(Exception innerException)
//      : base(_message, innerException) {
//    }

//    /// <summary>
//    /// Initializes constructor with required parameter.
//    /// </summary>
//    /// <param name="message">Concurrency message</param>
//    /// <param name="innerException">Inner exception.</param>
//    public TKInvalidUserException(string message, Exception innerException)
//      : base(message, innerException) {
//    }

//    #endregion Constructor

//    /// <summary>
//    /// Gets the type of the TK error.
//    /// </summary>
//    /// <value>
//    /// The type of the TK error.
//    /// </value>
//    public override ErrorType GetTKErrorType()
//    {
//      return ErrorType.Authentication;
//    }
//  }
//}
