using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Data.Repository
{
   public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public PlaylistRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTrack(int id, Track track)
        {
            var entity = Get(id);
            unitOfWork.Entry(entity).Reference(a => a.Tracks).Load();
            entity.Tracks.Add(track);
        }
    }
}
