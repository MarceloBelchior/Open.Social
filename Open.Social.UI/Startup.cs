﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Open.Social.Core.Model.config;

namespace Painel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Autofac.IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //        .RequireAuthenticatedUser().Build());
            //});

            //services.ConfigureApplicationCookie(options => options.LoginPath = "/OAuth/Login/Index");

            //services.AddAuthentication();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
        {
            options.LoginPath = "/OAuth/Login/Index";
            options.LogoutPath = "/OAuth/Login/logout";
        });


            services.AddOptions();
            // Add framework services.
            services.Configure<DocumentDbConfig>(Configuration.GetSection("DocumentDb"));
            //https://andrewlock.net/reloading-strongly-typed-options-in-asp-net-core-1-1-0/
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<DocumentDbConfig>>().Value);
            services.AddScoped<Open.Social.UI.Interface.IUserManager, Open.Social.UI.Manager.UserManager>();
            services.AddMvc();
            // Create the Autofac container builder.
            var builder = new ContainerBuilder();

            // Add any Autofac modules or registrations.           
            builder.RegisterModule(new Open.Social.AzureDocumentDb.IoC.AutofacModule());
            builder.RegisterModule(new Open.Social.Service.IoC.AutofacModule());
            builder.RegisterModule(new Open.Social.AzureDocumentDb.IoC.AutofacModule());


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
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {



                // routes.MapRoute(name: "OAuth",  template: "OAuth/{controller=Login}/{action=Index}/{id?}");


                routes.MapRoute(
           name: "default",
           template: "{controller=Open}/{action=Index}/{id?}");
                //routes.MapSpaFallbackRoute(
                //    name: "spa-fallback",
                //    defaults: new { controller = "Open", action = "Index" });
            });



        }
    }
}
