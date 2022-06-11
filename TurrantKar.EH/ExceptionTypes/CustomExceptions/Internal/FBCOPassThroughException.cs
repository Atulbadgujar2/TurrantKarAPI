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
  /// The exception that is thrown by the exception handling block to replace the exception from data layer.
  /// </summary>
  [Serializable]
  public class TKPassThroughException : BaseException {

    #region Local Members

    private static readonly string _message = "Pass this exception to an outer level.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    public TKPassThroughException()
      : base(_message) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    public TKPassThroughException(string message)
      : base(message) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="inner">Inner exception.</param>
    public TKPassThroughException(string message, System.Exception inner)
      : base(message, inner) {
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
      return ErrorType.PassThroughException;
    }
  }
}
