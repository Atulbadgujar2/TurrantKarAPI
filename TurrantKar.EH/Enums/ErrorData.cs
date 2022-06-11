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

namespace TurrantKar.EH {

  /// <summary>
  /// This class contains the error properties for service. 
  /// It is used to handle webfault exception with custom xml element.
  /// </summary>
  [DataContract]
  public class ErrorData {

    /// <summary>
    /// Initializes a new instance of the Error Data class.  
    /// </summary>
    /// <param name="message">Title of exception.</param>
    /// <param name="detailedInformation">Detail information of exception.</param>
    /// <param name="statusCode">Error Status code.</param>
    /// <param name="severity">Severity.</param>
    /// <param name="url">Url.</param>
    /// <param name="validVersion">Valid Version.</param>
    /// <param name="error">Error.</param>
    /// <param name="reportUrl">Report Url.</param>
    public ErrorData(string message, string detailedInformation, string statusCode, string severity, string url = "", bool validVersion = false, bool error = true, string reportUrl = "") {
      Message = message;
      DetailedInformation = detailedInformation;
      StatusCode = statusCode;
      Severity = severity;
      ServiceUrl = url;
      ValidVersion = validVersion;
      Error = error;
      ReportUrl = reportUrl;
    }


    /// <summary>
    /// Default constructor.
    /// </summary>
    public ErrorData() {
    }

    /// <summary>
    /// Eexception message.
    /// </summary>
    [DataMember]
    public string Message {
      get;
      set;
    }

    /// <summary>
    /// Detail information of exception.
    /// </summary>
    [DataMember]
    public string DetailedInformation {
      get;
      set;
    }

    /// <summary>
    /// Http status code.
    /// </summary>
    [DataMember]
    public string StatusCode {
      get;
      set;
    }

    /// <summary>
    /// Exception severity.
    /// </summary>
    [DataMember]
    public string Severity {
      get;
      set;
    }

    /// <summary>
    /// Valid Service Url for current version
    /// </summary>
    [DataMember]
    public string ServiceUrl {
      get;
      set;
    }

    /// <summary>
    /// Return true if version is valid else return false.
    /// </summary>
    [DataMember]
    public bool ValidVersion {
      get;
      set;
    }


    /// <summary>
    /// Return true if version is valid else return false.
    /// </summary>
    [DataMember]
    public bool Error {
      get;
      set;
    }

    /// <summary>
    /// Report URL.
    /// </summary>
    [DataMember]
    public string ReportUrl {
      get;
      set;
    }

  }
}