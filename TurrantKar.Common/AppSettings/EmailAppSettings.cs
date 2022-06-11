/* Copyright © 2021 ThinkAI (). All Rights Reserved.
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* Author: Atul Badgujar <atul.badgujar2@gmail.com>
* Date: 27 April 2021
* 
* Contributor/s: 
* Last Updated On: 27 April 2021
*/

namespace TurrantKar.Common
{
    public class EmailAppSettings
    {
        public string SenderKey
        {
            get; set;
        }

        public string SenderEmail
        {
            get; set;
        }

        public string SenderDisplayName
        {
            get; set;
        }

        public string SenderUserId
        {
            get; set;
        }

        public string SenderPwd
        {
            get; set;
        }

        public string SMTPServer
        {
            get; set;
        }

        public string SMTPPort
        {
            get; set;
        }

        public string Default
        {
            get; set;
        }

        public string EnableSSL
        {
            get; set;
        }

     

        public ushort DispatcherType
        {
            get; set;
        }
    }
}
