using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.Repositories
{
   public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        void AddTrack(int id, Track track);
    }
}
