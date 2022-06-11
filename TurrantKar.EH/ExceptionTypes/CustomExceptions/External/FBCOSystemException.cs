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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurrantKar.EH {

  /// <summary>
  /// It is a custom exception class inherited to base exception. It is use for duplicate name found.
  /// </summary>
  [Serializable]
  public class TKSystemException : TKRecoverableException {

    #region Local Members

    private static readonly string _message = "System error";

    #endregion Local Members

    #region Constructor

    /// <summary>
    /// Initializes constructor with no parameter.
    /// </summary>
    public TKSystemException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Concurrency message.</param>
    public TKSystemException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKSystemException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Concurrency message.</param>
    /// <param name="innerException">Inner exception.</param>
    public TKSystemException(string message, Exception innerException)
      : base(message, innerException) {
    }


    /// <summary>
    /// Initialize constructor with required parameter.
    /// </summary>    
    /// <param name="message">Error message.</param>
    /// <param name="dataList">Validation data.</param>
    public TKSystemException(string message, IList<TKErrorData> dataList)
      : base(message, null) {
      ErrorDataList = dataList;
    }

    #endregion Constructor

    /// <summary>
    /// Gets the type of the TK error.
    /// </summary>
    /// <value>
    /// The type of the TK error.
    /// </value>
    public override ErrorType GetTKErrorType() {
      return ErrorType.System;
    }

  }
}
