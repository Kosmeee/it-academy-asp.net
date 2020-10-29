using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ItAcademy.Project.Music.Client.Interfaces.PresentationServices;
using ItAcademy.Project.Music.Client.Models;
using ItAcademy.Project.Music.Client.Util.Mapper;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;

namespace ItAcademy.Project.Music.Client.Areas.Admin.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly ITrackPresentationService trackPresentationService;

        // GET: Admin/Track
        public TrackController(ITrackDomainService trackDomainService, ITrackPresentationService trackPresentationService)
        {
            this.trackDomainService = trackDomainService;
            this.trackPresentationService = trackPresentationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ViewAll()
        {
            var trackslist = trackDomainService.GetTracks();
            List<ViewTrack> viewTrackList = new List<ViewTrack>();
            foreach (var a in trackslist)
            {
                viewTrackList.Add(Mapper.TrackToViewTrack(a));
            }

            return PartialView("ViewTracks", viewTrackList);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewTrack viewTrack = new ViewTrack();

            viewTrack = Mapper.TrackToViewTrack(trackDomainService.FindTrack(id));
            return View("EditTrack", viewTrack);
        }

        [HttpPost]
        public ActionResult Edit(ViewTrack viewTrack)
        {
            if (ModelState.IsValid)
            {
                trackPresentationService.ChangeTrack(viewTrack);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditTrack", viewTrack);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("EditTrack", new ViewTrack());
        }

        [HttpPost]
        public ActionResult Add(ViewTrack viewTrack)
        {
            if (ModelState.IsValid)
            {
                viewTrack.AddedDate = DateTime.Now;
                trackPresentationService.AddTrack(viewTrack);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditTrack", new ViewTrack());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            trackDomainService.DeleteTrack(id);

            return RedirectToAction("Index", "Admin");
        }
    }
}