using System.Web;
using System.Web.Mvc;
using ItAcademy.Project.Music.Client.App_Start.Core;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;
using Microsoft.AspNet.Identity.Owin;

namespace ItAcademy.Project.Music.Client.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistDomainService playlistDomainService;
        private readonly IAppUserDomainService appUserDomainService;

        public PlaylistController(IPlaylistDomainService playlistDomainService, IAppUserDomainService appUserDomainService)
        {
            this.playlistDomainService = playlistDomainService;
            this.appUserDomainService = appUserDomainService;
        }

        public ViewResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user.Playlist);
        }

        public ActionResult AddTrack(Track track)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            playlistDomainService.AddTrack(appUserDomainService.GetPlaylistId(user), track);
            return RedirectToAction("Index", "Playlist");
        }
    }
}