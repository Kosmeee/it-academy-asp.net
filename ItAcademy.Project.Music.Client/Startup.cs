using ItAcademy.Project.Music.Client.App_Start.Core;
using ItAcademy.Project.Music.Data.Context;
using ItAcademy.Project.Music.Domain.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ItAcademy.Project.Music.Client.Startup))]

namespace ItAcademy.Project.Music.Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             app.CreatePerOwinContext(() => new MusDbContext());
             app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

             app.CreatePerOwinContext<RoleManager<ApplicationRole>>((options, context) =>
             new RoleManager<ApplicationRole>(
              new RoleStore<ApplicationRole>(context.Get<MusDbContext>())));
             app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}
