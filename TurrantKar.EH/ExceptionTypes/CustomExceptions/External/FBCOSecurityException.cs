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
  /// It is a custom exception class inherited from base exception class. 
  /// It is used to pass exception when operation is invalid.
  /// </summary>
  [Serializable]
  public class TKSecurityException : TKRecoverableException {

    #region Local Members

    private static readonly string _message = "Unauthorized user.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    public TKSecurityException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    public TKSecurityException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="innerException"></param>
    public TKSecurityException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>    
    /// <param name="message">Error message.</param>
    /// <param name="dataList">Validation data.</param>
    public TKSecurityException(string message, IList<TKErrorData> dataList)
      : base(message, null) {
      ErrorDataList = dataList;
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
      return ErrorType.Security;
    }

  }
}
