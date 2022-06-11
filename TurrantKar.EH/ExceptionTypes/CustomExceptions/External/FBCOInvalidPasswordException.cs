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
  /// It is used when login password is wrong.
  /// </summary>
  [Serializable]
  public class TKInvalidPasswordException : TKRecoverableException {

    #region Local Members

    private static readonly string _message = "Invalid password.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    public TKInvalidPasswordException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    public TKInvalidPasswordException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKInvalidPasswordException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public TKInvalidPasswordException(string message, Exception innerException)
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
