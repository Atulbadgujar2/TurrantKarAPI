/* Copyright © 2021 ThinkAI (). All Rights Reserved.
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* Author: Atul Badgujar <atul.badgujar2@gmail.com>
* Date: 05 April 2021
* 
* Contributor/s: 
* Last Updated On: 05 April 2021
*/

using System.Runtime.Serialization;

namespace TurrantKar.EH
{

  /// <summary>
  /// This class contains the error properties for service. 
  /// It is used to handle webfault exception with custom xml element.
  /// </summary>
  [DataContract]
  public class TKErrorData {

    #region Constructor

    /// <summary>
    /// Default constructor.
    /// </summary>
    public TKErrorData() {
    }

    /// <summary>
    /// Initializes a new instance of the Error Data class.  
    /// </summary>
    /// <param name="errorSubType">Error sub type enum value.</param>
    /// <param name="data">Error data.</param>
    /// <param name="msg">Error message.</param>
    public TKErrorData(int errorSubType, object data, string msg) {
      ErrorSubType = errorSubType;
      Data = data;
      Message = msg;
    }

    #endregion Constructor

    /// <summary>
    /// Eexception message.
    /// </summary>
    [DataMember]
    public int ErrorSubType {
      get;
      set;
    }


    /// <summary>
    /// Detail information of exception.
    /// </summary>
    [DataMember]
    public object Data {
      get;
      set;
    }

  
    /// <summary>
    /// Http status code.
    /// </summary>
    [DataMember]
    public string Message {
      get;
      set;
    }

  }
}