using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.Repositories
{
   public interface ITrackRepository : IBaseRepository<Track>
    {
        List<Track> GetFiveTracks();

        List<Track> GetAllWithAllAttachments();

        Track FindTrack(int id);
    }
}
