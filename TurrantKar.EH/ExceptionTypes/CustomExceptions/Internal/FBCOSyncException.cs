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
using System.Collections.Generic;

namespace TurrantKar.EH {

  /// <summary>
  /// The exception that is thrown by exception handling block to replace the original exception,
  /// occurred in DataService layer, with a user friendly message.
  /// </summary>
  [Serializable]
  public class TKSyncException : BaseException {

    private static readonly string _message = "An error occurred during data sync operation.";

    #region Constructors

    /// <inheritdoc />
    public TKSyncException()
      : base(_message) {
    }

    /// <inheritdoc />
    public TKSyncException(string message)
      : base(message) {
    }

    /// <inheritdoc />
    public TKSyncException(string message, System.Exception inner)
      : base(message, inner) {    
    }
       /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>    
    /// <param name="message">Error message.</param>
    /// <param name="dataList">Validation data.</param>
    public TKSyncException(string message, IList<TKErrorData> dataList)
      : base(message, null) {     
      ErrorDataList = dataList;
    }

    #endregion



    /// <summary>
    /// Gets the type of the TK error.
    /// </summary>
    /// <returns></returns>
    /// <value>
    /// The type of the TK error.
    /// </value>
    public override ErrorType GetTKErrorType()
    {
     return ErrorType.SyncException;
    }
  }
}
