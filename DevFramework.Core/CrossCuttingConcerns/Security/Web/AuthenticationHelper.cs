using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {

        public static void CreateAuthCookie(Guid id, string Username, string email, DateTime expiration, string[] roles,
            bool rememberMe, string firstName, string lastName)
        {
            //var authTicket = new FormsAuthenticationTicket(1, Username, DateTime.Now, expiration, rememberMe,
            //    CreateAuthTags(email, roles, firstName, lastName,Guid id));
            //string encTicket = FormsAuthenticationTicket.Encrypt(authTicket);
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthenticationTicket.FormsCookieName, encTikect));

        }

        private static object CreateAuthTags(string email, string[] roles, string firstName, string lastName,Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);

            return stringBuilder.ToString();

        }
    }
}
