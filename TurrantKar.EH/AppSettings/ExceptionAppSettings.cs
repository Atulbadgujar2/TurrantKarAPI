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

using System;
using System.Collections.Generic;
using System.Text;

namespace TurrantKar.EH {

  /// <summary>
  /// This class contains application settings.
  /// Note that AppSettings objects are parsed from json.
  /// </summary>
  public class ExceptionAppSettings {

    public string AppName {
      get; set;
    }

    public string SMTPServer {
      get; set;
    }


    public string SenderUserId {
      get; set;
    }


    public string SenderPwd {
      get; set;
    }


    public int SMTPPort {
      get; set;
    }



    public bool EnableSSL {
      get; set;
    }

    public string SenderEmail {
      get; set;
    }


    public string ReceiverEmail {
      get; set;
    }

    public string ServerName {
      get; set;
    }

    public bool EnableErrorEmail {
      get; set;
    }
  }
}
