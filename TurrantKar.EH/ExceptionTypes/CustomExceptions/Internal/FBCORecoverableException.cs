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
  /// It is a base exception class inherited from System.ApplicationException class.
  /// All other custom exception will be inherited from this class.
  /// </summary>
  [Serializable]
  public class TKRecoverableException : BaseException {

    #region Local Members

    private static readonly string _message = "Invalid entity.";

    #endregion Local Members

    #region Constructor

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    public TKRecoverableException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    public TKRecoverableException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="innerException">inner exception.</param>
    public TKRecoverableException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">inner exception.</param>
    public TKRecoverableException(string message, Exception innerException)
      : base(message, innerException) {
    }

    #endregion Constructor

    /// <summary>
    /// Gets the type of the TK error.
    /// </summary>
    /// <value>
    /// The type of the TK error.
    /// </value>
    public override ErrorType GetTKErrorType()
    {
      return ErrorType.RecoverableException;
    }
  }
}
