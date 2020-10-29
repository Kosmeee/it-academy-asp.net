using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.Repositories
{
   public interface IArtistRepository : IBaseRepository<Artist>
    {
        List<Artist> GetAllWithAllAttachments();

        Artist FindArtist(int id);
    }
}
