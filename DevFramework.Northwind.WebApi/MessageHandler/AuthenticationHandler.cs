using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFramework.Northwind.WebApi.MessageHandler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');
                    //IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    if (tokenValues[0] == "engin" && tokenValues[1] == "12345")
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), new[] { "Admin" });
                        Thread.CurrentPrincipal = principal;
                        //HttpContext.Current.User = principal;

                    }
                }
            }
            catch
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
