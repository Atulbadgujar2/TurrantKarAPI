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

using Microsoft.Extensions.Configuration;
using Serilog;

namespace TurrantKar.SerilogLoggingService
{
    public static class LoggerFactory {
    public static void SetDefaultAppLogger() {
      // Seri Log Settings Start
      //string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      var configuration = new ConfigurationBuilder()
                  .AddJsonFile($"AppSettings/appsettings.dev.json")
                  .Build();
      string appName = configuration.GetValue<string>("AppName");
      string appVersion = configuration.GetValue<string>("AppVersion");
      string deployment = configuration.GetValue<string>("Deployment");
      LoggerModel model = new LoggerModel { AppName = appName, AppVersion = appVersion, DeploymentName = deployment, SeqURL = "http://ewp-dev22.eworkplaceapps.com:5341" };
      Log.Logger = SerilogLogger.Configure(model, null);
      // Seri Log Settings End
    }
  }
}
