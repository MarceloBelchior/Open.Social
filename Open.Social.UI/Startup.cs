using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Open.Social.Core.Model.config;
using Open.Social.Utils.JWT;

namespace Painel
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();


        }

        public IConfiguration Configuration { get; }
        public Autofac.IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
                  
            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddCookie(opt =>
                {
                    opt.LoginPath = Configuration["PathLogin"];
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
                
       
            services.AddMvc();


            services.AddOptions();

            services.Configure<DocumentDbConfig>(Configuration.GetSection("DocumentDb"));
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<DocumentDbConfig>>().Value);
            services.AddMvc();
            var builder = new ContainerBuilder();
            builder.RegisterModule(new Open.Social.AzureDocumentDb.IoC.AutofacModule());
            builder.RegisterModule(new Open.Social.Service.IoC.AutofacModule());
            builder.RegisterModule(new Open.Social.UI.IoC.AutofacModule());
            services.AddOptions();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();


            return new AutofacServiceProvider(this.ApplicationContainer);
        }


        private static Task OnRedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
        {
            // your logic may vary, this logic should reflect
            //    whichever pattern distinguishes this as an api request 
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                // override the status code
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Task.CompletedTask;
            }

            // all other requests we'll assume should redirect to a login page
            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
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
                routes.MapRoute(
           name: "default",
           template: "{controller=Open}/{action=Index}/{id?}");
            });



        }
    }
}
