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

namespace TurrantKar.EH
{

  /// <summary>
  /// It is a custom exception class inherited to base exception. It is use for service call.
  /// </summary>
  [Serializable]
  public class TKHttpResponseException : TKRecoverableException
  {

    #region Local Members

    //private static readonly string _message = "This item has been updated or deleted by another user. Please reload the item and then retry your operation.";
    private static readonly string _message = "An error occurred during service operation.";
    private static string _responseExMessage;
    private static int _statuscode;

    #endregion Local Members

    #region Constructor

    /// <inheritdoc />
    public TKHttpResponseException()
      : base(_message, null)
    {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Concurrency message.</param>
    public TKHttpResponseException(string message)
      : base(message, null)
    {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="innerException">Inner exception.</param>
    public TKHttpResponseException(Exception innerException)
      : base(_message, innerException)
    {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="innerException">Inner exception.</param>
    public TKHttpResponseException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Error mesage.</param>
    /// <param name="responseExMessage">The response ex message.</param>
    public TKHttpResponseException(string message, string responseExMessage)
      : base(message, null)
    {
      _responseExMessage = responseExMessage;
    }



    /// <summary>
    /// Initializes constructor with required parameter.
    /// </summary>
    /// <param name="message">Error mesage.</param>
    /// <param name="responseExMessage">The response ex message.</param>
    public TKHttpResponseException(string message, string responseExMessage, int statuscode)
      : base(message, null)
    {
      _responseExMessage = responseExMessage;
      _statuscode = statuscode;
    }

    /// <summary>
    /// Gets the response exception message.
    /// </summary>
    /// <value>
    /// The response exception message.
    /// </value>
    public string ResponseExceptionMessage
    {
      get
      {
        return _responseExMessage;
      }
    }

    /// <summary>
    /// Gets the response exception message.
    /// </summary>
    /// <value>
    /// The response exception message.
    /// </value>
    public int ResponseStatusCode
    {
      get
      {
        return _statuscode;
      }

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
      return ErrorType.ResponseException;
    }
  }
}
