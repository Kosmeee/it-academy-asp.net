using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.DomainServices.Interfaces
{
    public interface IArtistDomainService
    {
        Artist Get(int id);

        List<Artist> GetArtists();

        Artist FindArtist(int id);

        void DeleteArtist(int id);

        void AddArtist(Artist artist);

        void ChangeArtist();
    }
}
