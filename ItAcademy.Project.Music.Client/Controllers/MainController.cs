using System.Web.Mvc;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;

namespace ItAcademy.Project.Music.Client.Controllers
{
    public class MainController : Controller
    {
        private readonly ITrackDomainService trackDomainService;

        public MainController(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }

        public ActionResult Index()
        {
            return View(trackDomainService.GetFiveTracks());
        }
    }
}