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


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace TurrantKar.EH
{

  /// <summary>
  /// Struct hold the structure of error. It contain all necessary information of generated error.
  /// </summary>
  [DataContract]
  public class TKError {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the TKError class.  
    /// </summary>
    public TKError() {
      MessageList = new List<string>();
      TKErrorDataList = new List<TKErrorData>();
    }

    /// <summary>
    /// Initializes a new instance of the TKError class.  
    /// </summary>
    /// <param name="errorType">Error Type</param>
    /// <param name="msgs">Message List</param>
    /// <param name="dataList">Data List</param>
    public TKError(ErrorType errorType, List<string> msgs, IList<TKErrorData> dataList) {
      ErrorType = errorType;
      MessageList = msgs;
      TKErrorDataList = dataList;
    }

    /// <summary>
    /// To the json.
    /// </summary>
    /// <param name="TKError">The TK error.</param>
    /// <returns>Returns a srting of Json type </returns>
    public static string ToJSON(TKError TKError)
    {
      string jsonError = string.Empty;
      jsonError = Newtonsoft.Json.JsonConvert.SerializeObject(TKError);
      return jsonError;
    }

    public String ToJson()
    {
      return JsonConvert.SerializeObject(this);
    }

    public class Exception
    {
      public Exception(TKError TKError)
      {
        this.TKError = TKError;
      }

      TKError TKError;
    }

    #endregion Constructor

    #region Properties

    /// <summary>
    /// Error type indicate the type of error. It may be validation, system error.
    /// </summary>
    [DataMember]
    public ErrorType ErrorType {
      get;
      set;
    }

    /// <summary>
    /// Message array hold the array of messages to show.
    /// </summary>   
    [DataMember]
    public List<string> MessageList {
      get;
      set;
    }

    /// <summary>
    /// The TK error data list.
    /// </summary>
    [DataMember]
    public IList<TKErrorData> TKErrorDataList {
      get;
      set;
    }

    public override string ToString() {
      return JsonConvert.SerializeObject(this);
    }

    #endregion Properties

    #region XML

    // -------------------- XML --------------------

    /* XML:
       <TKError>
         <ErrorType></ErrorType>
         <MessageList>
          <Message></Message>
          <Message></Message>
           ...
         </MessageList>
         <DataList>
           <Data Key=""  Value=""></Data>
           <Data Key=""  Value=""></Data>
           ...
         </DataList>
       </TKError>
   */

    /// <summary>
    /// To the XML writer.
    /// </summary>
    /// <param name="TKError">The TK error.</param>
    /// <returns>Returns the xml documents </returns>
    public static XmlDocument ToXmlWriter(TKError TKError) {

      XmlDocument xmlDoc = new XmlDocument();

      XmlElement rootNode = xmlDoc.CreateElement("TKServiceErrorData");
      xmlDoc.AppendChild(rootNode);

      XmlElement node = xmlDoc.CreateElement("ErrorType");
      node.InnerText = Convert.ToString(TKError.ErrorType);
      rootNode.AppendChild(node);

      XmlElement DataListNode = xmlDoc.CreateElement("DataList");
      rootNode.AppendChild(DataListNode);
      foreach (TKErrorData data in TKError.TKErrorDataList) {
        XmlElement dataNode = xmlDoc.CreateElement("Data");

        XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Key");
        nameAttribute.Value = Convert.ToString((int)data.ErrorSubType);
        dataNode.Attributes.Append(nameAttribute);

        XmlAttribute valueAttribute = xmlDoc.CreateAttribute("Value");
        valueAttribute.Value = Convert.ToString(data.Data);
        dataNode.Attributes.Append(valueAttribute);

        DataListNode.AppendChild(dataNode);
      }

      XmlElement messageListNode = xmlDoc.CreateElement("MessageList");
      rootNode.AppendChild(messageListNode);
      foreach (string msg in TKError.MessageList) {
        XmlElement msgNode = xmlDoc.CreateElement("Message");
        msgNode.InnerText = msg;
        messageListNode.AppendChild(msgNode);
      }

      return xmlDoc;
    }

    #endregion XML

    #region JSON

    // -------------------- XML --------------------

    /* XML:
       <TKError>
         <ErrorType></ErrorType>
         <MessageList>
          <Message></Message>
          <Message></Message>
           ...
         </MessageList>
         <DataList>
           <Data Key=""  Value=""></Data>
           <Data Key=""  Value=""></Data>
           ...
         </DataList>
       </TKError>
   */



    #endregion JSON
  }

}