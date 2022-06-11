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
  /// It is used to ignore.
  /// </summary>
  [Serializable]
  public class TKIgnoredException : BaseException {

    #region Local Members

    private static readonly string _message = "Ignore this error.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Intialize class constructor.
    /// </summary>
    public TKIgnoredException()
      : base(_message, null) {
    }

    /// <summary>
    /// Intitialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Message from exception.</param>
    public TKIgnoredException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Intitialize constructor with required parameter.
    /// </summary>
    /// <param name="innerException">Inner exception message.</param>
    public TKIgnoredException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Intitialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public TKIgnoredException(string message, Exception innerException)
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
      return ErrorType.IgnoreException;
    }
  }
}
