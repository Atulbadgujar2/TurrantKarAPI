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
  /// It is use for import data opration 
  /// </summary>
  [Serializable]
  public class TKImportDataException : TKRecoverableException {

    #region Local Members

    private static readonly string _message = "Exception occured to import data.";

    #endregion Local Members

    #region Constructors

    /// <summary>
    /// Initialize default constructor.
    /// </summary>
    public TKImportDataException()
      : base(_message, null) {
    }

    /// <summary>
    /// Initialize parameterized constructor.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public TKImportDataException(string message)
      : base(message, null) {
    }

    /// <summary>
    /// Initialize parameterized constructor.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKImportDataException(Exception innerException)
      : base(_message, innerException) {
    }

    /// <summary>
    /// Initialize parameterized constructor.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="erros">The erros.</param>
    public TKImportDataException(string message, List<TKErrorData> erros)
      : base(message, null) {
        ErrorDataList = erros;
    }

    /// <summary>
    /// Initialize parameterized constructor.
    /// </summary>
    /// <param name="erros">The erros.</param>
    public TKImportDataException(List<TKErrorData> erros)
      : base(_message, null) {
        ErrorDataList = erros;
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
      return ErrorType.ImportData;
    }
  }
}
