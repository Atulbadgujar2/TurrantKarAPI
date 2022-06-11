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

namespace TurrantKar.EH {

  /// <summary>
  /// It is a custom exception class inherited from base exception class.
  /// It is used to when user is locked due to wrong authentication.
  /// </summary>
  [Serializable]
  public class TKUserLockedException : TKRecoverableException {

    #region Local Members

    private static readonly string _message = "User is locked out due to 4 wrong password attempts.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    public TKUserLockedException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    public TKUserLockedException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKUserLockedException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public TKUserLockedException(string message, Exception innerException)
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
      return ErrorType.Authentication;
    }
  }

}
