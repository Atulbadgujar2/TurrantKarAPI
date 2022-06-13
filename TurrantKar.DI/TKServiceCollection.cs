﻿/* Copyright © 2021 ThinkAI (). All Rights Reserved.
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * 
 * Author: Atul Badgujar <atul.badgujar2@gmail.com>
 * Date: 08 Feb 2021
 * 
 * Contributor/s: 
 * Last Updated On: 08 Feb 2021
 */

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using TK.Data;
using TurrantKar.Common;
using TurrantKar.DS;
using TurrantKar.EH;
using TurrantKar.Repository;
using TurrantKar.SerilogLoggingService;

namespace TurrantKar.DI
{
    public static class TKServiceCollection
    {
        public static IServiceCollection AddTKDependency(this IServiceCollection services, IConfiguration Configuration)
        {
            AddTKDataDependency(services);
            AddTKDataServiceDependency(services);
            AddOtherDependency(services, Configuration);
            return services;
        }

        //Added All Data Dependency 
        public static IServiceCollection AddTKDataDependency(this IServiceCollection services)
        {
            services.AddDbContext<TKDBContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>(x =>
                      new UnitOfWork(x.GetRequiredService<TKDBContext>(),
                                             false
                                            ));
            services.AddScoped<IAddressRepository, AddressRepository>();
           

            return services;
        }

        //Added All DataService Dependency 
        public static IServiceCollection AddTKDataServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IAddressDS, AddressDS>();
            return services;
        }

        //Added All Others Dependency 
        public static IServiceCollection AddOtherDependency(this IServiceCollection services, IConfiguration Configuration)
        {

            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings"))
             .AddJsonFile($"appsettings.dev.json", false, true);

            var configuration = builder.Build();

            // TK Config Settings  
            var TKSection = configuration.GetSection("ConnectionStrings");
            services.Configure<ConnectionStrings>(TKSection);


            // TK Email Config Settings 
            var emailSection = configuration.GetSection("EmailSmtpAppSettings");
            services.Configure<EmailAppSettings>(emailSection);

            //Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
           {
               mc.AddProfile(new MappingProfile());
           });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            return services;
        }

        public static IConfiguration InitAppSetting(IConfiguration configuration)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder()
             .AddConfiguration(configuration)
             .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings"))
             .AddJsonFile($"appsettings.dev.json", false, true);
             
            return builder.Build();
        }

        public static IApplicationBuilder AddTKMiddleware(this IApplicationBuilder app)
        {

            app.AddExceptionMiddleware();

            //// Custome User session Middelware
            //app.AddUserSessionMiddleware(new UserSessionOptions() { LightSession = false });

            //Serilog Middleware
            app.UseMiddleware<SerilogHttpMiddleware>(Options.Create(new SerilogHttpMiddlewareOptions()
            {
                EnableExceptionLogging = false
            }));

            return app;
        }

    }
}
