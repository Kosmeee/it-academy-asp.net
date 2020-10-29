using ItAcademy.Project.Music.Client.Interfaces.PresentationServices;
using ItAcademy.Project.Music.Client.Models;
using ItAcademy.Project.Music.Client.Util.Mapper;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Client.PresentationServices
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IArtistDomainService artistDomainService;
        private readonly IAlbumDomainService albumDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService, IGenreDomainService genreDomainService, IArtistDomainService artistDomainService, IAlbumDomainService albumDomainService)
        {
            this.trackDomainService = trackDomainService;
            this.genreDomainService = genreDomainService;
            this.artistDomainService = artistDomainService;
            this.albumDomainService = albumDomainService;
        }

        public void ChangeTrack(ViewTrack viewTrack)
        {
            Track track = trackDomainService.FindTrack(viewTrack.Id);
            track = Mapper.EditTrackToTrack(viewTrack, track);
            track.Artist = artistDomainService.Get(viewTrack.Artist.Id);
            track.Album = albumDomainService.Get(viewTrack.Album.Id);
            track.Genre = genreDomainService.Get(viewTrack.Genre.Id);
            trackDomainService.ChangeTrack();
        }

        public void AddTrack(ViewTrack viewTrack)
        {
            Track track = Mapper.ViewTrackToTrack(viewTrack);
            track.Artist = artistDomainService.Get(viewTrack.Artist.Id);
            track.Album = albumDomainService.Get(viewTrack.Album.Id);
            track.Genre = genreDomainService.Get(viewTrack.Genre.Id);
            trackDomainService.AddTrack(track);
        }
    }
}