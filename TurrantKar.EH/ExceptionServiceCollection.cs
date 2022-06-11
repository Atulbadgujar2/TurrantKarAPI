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


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TurrantKar.EH
{

    public static class ExceptionServiceCollection {

        public static IServiceCollection AddExceptionDependency(this IServiceCollection services, IConfiguration Configuration)
        {
            Microsoft.Extensions.Configuration.IConfigurationSection exceptionSection = Configuration.GetSection("ExceptionAppSettings");
            //services.Configure<ExceptionAppSettings>(exceptionSection);
            return services;
        }

        public static IApplicationBuilder AddExceptionMiddleware(this IApplicationBuilder app) {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            return app;
        }

    }
}
