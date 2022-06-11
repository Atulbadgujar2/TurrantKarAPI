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
  public class TKInvalidOperationException : BaseException {

    #region Local Members

    private static readonly string _message = "Invalid operation.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize constructor.
    /// </summary>
    public TKInvalidOperationException()
      : base(_message, null) {
    }

    ///// <summary>
    ///// Initialize constructor with required parameter.
    ///// </summary>
    ///// <param name="message">Error message.</param>
    //public TKInvalidOperationException(string message)
    //  : base(message, null) {
    //}

    ///// <summary>
    ///// Initialize constructor with required parameter.
    ///// </summary>
    ///// <param name="innerException">Inner exception.</param>
    //public TKInvalidOperationException(Exception innerException)
    //  : base(_message, innerException) {
    //}

    ///// <summary>
    ///// Initialize constructor with required parameter.
    ///// </summary>
    ///// <param name="message">Error message.</param>
    ///// <param name="innerException">Inner exception.</param>
    ///// <param name="opName">operation name.</param>
    //public TKInvalidOperationException(string message, Exception innerException, string opName = "")
    //  : base(message, innerException) {
    //  SetData(opName);
    //}

    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="subType">Inner exception.</param>
    /// <param name="data">operation name.</param>
    public TKInvalidOperationException(string message, InvalidOperationExceptionSubType subType = InvalidOperationExceptionSubType.MethodNotSupported, object data = null)
      : base(message, null) {      
      TKErrorData errorData = new TKErrorData() {
        Message = message,
        ErrorSubType = (int)subType,
        Data = data
      };
      ErrorDataList = new List<TKErrorData>() { errorData };
    }

    #endregion Constructors

    #region Public

    /// <summary>
    /// This method set operation name in excetpion.
    /// </summary>
    /// <param name="opName">Operation name.</param>
    public void SetData(string opName) {
      if (!string.IsNullOrEmpty(opName))
        SetData("OperationName", opName);
    }

    /// <summary>
    /// This Method get operation name from exception.
    /// </summary>
    public void GetData() {
      GetData("OperationName");
    }

    #endregion Public

    /// <summary>
    /// Gets the type of the TK error.
    /// </summary>
    /// <value>
    /// The type of the TK error.
    /// </value>
    public override ErrorType GetTKErrorType() {
      return ErrorType.InvalidOperation;
    }
  }
}
