using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjectsManagment.Data;
using ProjectsManagment.Data.Services;
using ProjectsManagment.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(ProjectsManagment.Web.Startup))]
namespace ProjectsManagment.Web
{
    
    public class Startup
    {
        public static string PublicClientId { get; private set; }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(PMContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // Note: Remove the following line before you deploy to production:
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}