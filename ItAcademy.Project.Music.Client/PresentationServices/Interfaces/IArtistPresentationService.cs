using ItAcademy.Project.Music.Client.Models;

namespace ItAcademy.Project.Music.Client.PresentationServices.Interfaces
{
    public interface IArtistPresentationService
    {
        void ChangeArtist(ViewArtist viewArtist);

        void AddArtist(ViewArtist viewArtist);
    }
}