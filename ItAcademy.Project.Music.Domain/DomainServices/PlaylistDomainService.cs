using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Domain.DomainServices
{
    public class PlaylistDomainService : IPlaylistDomainService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlaylistDomainService(IPlaylistRepository playlistRepository, IUnitOfWork unitOfWork)
        {
            this.playlistRepository = playlistRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddTrack(int id, Track track)
        {
            playlistRepository.AddTrack(id, track);
            unitOfWork.SaveChanges();
        }
    }
}
