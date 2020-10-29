using ItAcademy.Project.Music.Client.Models;

namespace ItAcademy.Project.Music.Client.Interfaces.PresentationServices
{
    public interface ITrackPresentationService
    {
        void ChangeTrack(ViewTrack viewTrack);

        void AddTrack(ViewTrack viewTrack);
    }
}