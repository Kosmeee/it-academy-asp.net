using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Domain.DomainServices
{
    public class AlbumDomainService : IAlbumDomainService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork unitOfWork;

        public AlbumDomainService(IAlbumRepository albumRepository, IUnitOfWork unitOfWork)
        {
            this.albumRepository = albumRepository;
            this.unitOfWork = unitOfWork;
        }

        public Album Get(int id)
        {
            return albumRepository.Get(id);
        }
    }
}
