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
  /// It is a custom exception class inherited to base exception. It is use for invalid database version.
  /// </summary>
  [Serializable]
  public class TKInvalidAppVersionException : TKRecoverableException {

    #region Local Members

    private static readonly string _message = "The given application version is invalid.";

    #endregion Local Members

    #region Constructor

    /// <inheritdoc />
    public TKInvalidAppVersionException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Concurrency message.</param>
    public TKInvalidAppVersionException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKInvalidAppVersionException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Concurrency message</param>
    /// <param name="innerException">Inner exception.</param>
    public TKInvalidAppVersionException(string message, Exception innerException)
      : base(message, innerException) {
    }

    /// <summary>
    /// Latest application verion on server
    /// </summary>  
    public string  LatestApplicationVersion {
      get;
      set;
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
      return ErrorType.InvalidVersion;
    }
  }
}
