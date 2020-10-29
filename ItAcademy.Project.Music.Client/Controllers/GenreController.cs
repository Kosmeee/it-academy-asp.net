using System.Web.Mvc;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;

namespace ItAcademy.Project.Music.Client.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreDomainService genreDomainService;

        public GenreController(IGenreDomainService genreDomainService)
        {
            this.genreDomainService = genreDomainService;
        }

        public ViewResult Index()
        {
            return View(genreDomainService.GetAll());
        }
    }
}