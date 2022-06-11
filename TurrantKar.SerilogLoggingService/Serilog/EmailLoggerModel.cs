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

namespace TurrantKar.SerilogLoggingService {
  /// <summary>
  /// Model class for Email Logging defination
  /// </summary>
  public class EmailLoggerModel {
    
    /// <summary>
    /// Deployment Name
    /// </summary>
    public string DeploymentName {
      get; set;
    }

    /// <summary>
    /// Sender Email Address
    /// </summary>
    public string SenderEmail {
      get; set;
    }
    /// <summary>
    /// Receiver Email Address
    /// </summary>
    public string ReceiverEmail {
      get; set;
    }
    /// <summary>
    /// Email Server
    /// </summary>
    public string EmailServer {
      get; set;
    }

    /// <summary>
    /// Email Server port
    /// </summary>
    public int EmailServerPort
    {
      get; set;
    }

    /// <summary>
    /// Email Server port
    /// </summary>
    public bool EmailServerSSLEnabled
    {
      get; set;
    } = false;
    /// <summary>
    /// Network User Name 
    /// </summary>
    public string UserName {
      get; set;
    }

    /// <summary>
    /// Network USer Password
    /// </summary>
    public string Password {
      get; set;
    }
    /// <summary>
    /// Email Subject
    /// </summary>
    public string EmailSubject {
      get; set;
    } = "Application Error";

  }
}
