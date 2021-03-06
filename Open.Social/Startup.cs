using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using Open.Social.Core.Model.config;

namespace Open.Social
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });


            services.AddOptions();
            // Add framework services.
            services.Configure<DocumentDbConfig>(Configuration.GetSection("DocumentDb"));
            //https://andrewlock.net/reloading-strongly-typed-options-in-asp-net-core-1-1-0/
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<DocumentDbConfig>>().Value);

            services.AddMvc();
            // Create the Autofac container builder.
            var builder = new ContainerBuilder();

            // Add any Autofac modules or registrations.           
            builder.RegisterModule(new AzureDocumentDb.IoC.AutofacModule());
            builder.RegisterModule(new Open.Social.Service.IoC.AutofacModule());
            builder.RegisterModule(new IoC.AutofacModule());
            

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                //{
                //    HotModuleReplacement = true
                //});
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();


            //#region Handle Exception 
            //app.UseExceptionHandler(appBuilder =>
            //{
            //    appBuilder.Use(async (context, next) =>
            //    {
            //        var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

            //        if (error != null && error.Error is SecurityTokenExpiredException)
            //        {
            //            context.Response.StatusCode = 401;
            //            context.Response.ContentType = "application/json";

            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
            //            {
            //                State = RequestState.NotAuth,
            //                Msg = "token expired"
            //            }));
            //        }
            //        else if (error != null && error.Error != null)
            //        {
            //            context.Response.StatusCode = 500;
            //            context.Response.ContentType = "application/json";
            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
            //            {
            //                State = RequestState.Failed,
            //                Msg = error.Error.Message
            //            }));
            //        }
            //        else await next();
            //    });
            //});
            //#endregion

            //#region UseJwtBearerAuthentication 
            //app.UseJwtBearerAuthentication(new JwtBearerOptions()
            //{
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        IssuerSigningKey = TokenAuthOption.Key,
            //        ValidAudience = TokenAuthOption.Audience,
            //        ValidIssuer = TokenAuthOption.Issuer,
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.FromMinutes(0)
            //    }
            //});
            //#endregion


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });


        }
    }
}
