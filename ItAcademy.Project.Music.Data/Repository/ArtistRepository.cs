using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Data.Repository
{
   public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public ArtistRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Artist FindArtist(int id)
        {
            var entity = Get(id);
            // unitOfWork.Entry(entity).Reference(a => a.Tracks).Load();
           // unitOfWork.Entry(entity).Reference(a => a.Albums).Load();
            unitOfWork.Entry(entity).Reference(a => a.Genre).Load();
            return entity;
        }

        public List<Artist> GetAllWithAllAttachments()
        {
            return GetQueryableItems()
                  .Include(a => a.Tracks)
                 .Include(a => a.Albums)
                 .Include(a => a.Genre)
                 .ToList();
        }
    }
}
