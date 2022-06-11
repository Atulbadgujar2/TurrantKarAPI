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
  /// The exception that is thrown by exception handling block to replace the original exception,
  /// occurred in DataService layer, with a user friendly message.
  /// </summary>
  [Serializable]
  public class TKDataServiceException : BaseException {

    private static readonly string _message = "An error occurred during data service operation.";

    #region Constructors

    /// <inheritdoc />
    public TKDataServiceException()
      : base(_message) {
    }

    /// <inheritdoc />
    public TKDataServiceException(string message)
      : base(message) {
    }

    /// <inheritdoc />
    public TKDataServiceException(string message, System.Exception inner)
      : base(message, inner) {    
    }

    #endregion

    /// <summary>
    /// Gets the type of the TK error.
    /// </summary>
    /// <value>
    /// The type of the TK error.
    /// </value>
    public override ErrorType GetTKErrorType()
    {
      return ErrorType.DataServiceException;
    }

  }
}
