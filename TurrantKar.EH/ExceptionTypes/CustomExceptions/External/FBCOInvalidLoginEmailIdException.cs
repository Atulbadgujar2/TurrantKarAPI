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
  /// It is used when login emial id is wrong.
  /// </summary>
  [Serializable]
  public class TKInvalidLoginEmailIdException : TKRecoverableException {

 #region Local Members

    

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    public TKInvalidLoginEmailIdException()
      : base("Invlid Email", null) {
    }

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    /// <param name="message">Error message.</param>
    public TKInvalidLoginEmailIdException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKInvalidLoginEmailIdException(Exception innerException)
      : base("Invalid email", innerException) {
    }

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public TKInvalidLoginEmailIdException(string message, Exception innerException)
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
