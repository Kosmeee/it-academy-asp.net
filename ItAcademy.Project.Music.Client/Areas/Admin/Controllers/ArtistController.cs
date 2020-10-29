using System.Collections.Generic;
using System.Web.Mvc;
using ItAcademy.Project.Music.Client.Models;
using ItAcademy.Project.Music.Client.PresentationServices.Interfaces;
using ItAcademy.Project.Music.Client.Util.Mapper;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;

namespace ItAcademy.Project.Music.Client.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IArtistPresentationService artistPresentationService;

        // GET: Admin/Artist
        public ArtistController(IArtistDomainService artistDomainService, IArtistPresentationService artistPresentationService)
        {
            this.artistDomainService = artistDomainService;
            this.artistPresentationService = artistPresentationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ViewAll()
        {
            var artistslist = artistDomainService.GetArtists();
            List<ViewArtist> viewArtistList = new List<ViewArtist>();
            foreach (var a in artistslist)
            {
                viewArtistList.Add(Mapper.ArtistToViewArtist(a));
            }

            return PartialView("ViewArtists", viewArtistList);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewArtist viewArtist = new ViewArtist();

            viewArtist = Mapper.ArtistToViewArtist(artistDomainService.FindArtist(id));
            return View("EditArtist", viewArtist);
        }

        [HttpPost]
        public ActionResult Edit(ViewArtist viewArtist)
        {
            if (ModelState.IsValid)
            {
                artistPresentationService.ChangeArtist(viewArtist);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditArtist", viewArtist);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("EditArtist", new ViewArtist());
        }

        [HttpPost]
        public ActionResult Add(ViewArtist viewArtist)
        {
            if (ModelState.IsValid)
            {
                artistPresentationService.AddArtist(viewArtist);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditArtist", new ViewArtist());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            artistDomainService.DeleteArtist(id);

            return RedirectToAction("Index", "Admin");
        }
    }
}