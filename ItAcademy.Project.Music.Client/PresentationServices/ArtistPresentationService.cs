using ItAcademy.Project.Music.Client.Models;
using ItAcademy.Project.Music.Client.PresentationServices.Interfaces;
using ItAcademy.Project.Music.Client.Util.Mapper;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Client.PresentationServices
{
    public class ArtistPresentationService : IArtistPresentationService
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IGenreDomainService genreDomainService;

        public ArtistPresentationService(IArtistDomainService artistDomainService, IGenreDomainService genreDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.genreDomainService = genreDomainService;
        }

        public void ChangeArtist(ViewArtist viewArtist)
        {
            Artist artist = artistDomainService.FindArtist(viewArtist.Id);
            artist = Mapper.EditArtistToArtist(viewArtist, artist);
            artist.Genre = genreDomainService.Get(viewArtist.Genre.Id);
            artistDomainService.ChangeArtist();
        }

        public void AddArtist(ViewArtist viewArtist)
        {
            Artist artist = Mapper.ViewArtistToArtist(viewArtist);
            artist.Genre = genreDomainService.Get(viewArtist.Genre.Id);
            artistDomainService.AddArtist(artist);
        }
    }
}