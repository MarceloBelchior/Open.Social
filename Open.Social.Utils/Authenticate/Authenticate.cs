using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace Open.Social.Utils.Authenticate
{
    public class Authenticate
    {
        //private static string CLIENT_ID = ConfigurationManager.AppSettings["OAuth_ClientId"];
        //private static string CLIENT_SECRET = ConfigurationManager.AppSettings["OAuth_ClientSecret"];
        //private static string TEST_USERNAME = ConfigurationManager.AppSettings["OAuth_Username"];
        //private static string TEST_PASSWORD = ConfigurationManager.AppSettings["OAuth_Password"];
        //private static string TOKEN_ENDPOINT = string.Format("{0}/Token", ConfigurationManager.AppSettings["hostApi"]);

        public static void LogOn(Model.User.Usuario user, int expiration, bool manualRedirect = false)
        {
            Microsoft.AspNetCore.Authentication.Cookies.for
            var ticket = new FormsAuthenticationTicket
                (
                1,
                    user.name,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(expiration),
                    false,
                    user.login,
                    FormsAuthentication.FormsCookiePath
            );


            string encTicket = FormsAuthentication.Encrypt(ticket);

            HttpContext.Current.Response.Cookies.Add(new HttpCookie
            (
                FormsAuthentication.FormsCookieName, encTicket)
            );



            if (!manualRedirect)
            {
                HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl);
            }
        }

        public static void LogOff(bool manualRedirect = false)
        {
            FormsAuthentication.SignOut();

            HttpContext.Current.Session.Abandon();

            if (!manualRedirect)
            {
                HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
            }
        }

        public static string GetAccessTokenString()
        {
            var client = new OAuth2Client(new Uri(TOKEN_ENDPOINT));
            return client.RequestResourceOwnerPasswordAsync(TEST_USERNAME, TEST_PASSWORD).Result.AccessToken;


        }

    }
}

