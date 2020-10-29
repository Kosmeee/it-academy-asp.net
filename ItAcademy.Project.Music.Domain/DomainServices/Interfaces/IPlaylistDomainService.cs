using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.DomainServices.Interfaces
{
    public interface IPlaylistDomainService
    {
        void AddTrack(int id, Track track);
    }
}
