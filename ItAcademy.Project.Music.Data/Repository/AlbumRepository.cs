using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Data.Repository
{
   public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public AlbumRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
