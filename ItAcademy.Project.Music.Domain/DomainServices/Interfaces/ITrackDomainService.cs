using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.DomainServices.Interfaces
{
   public interface ITrackDomainService
    {
        List<Track> GetFiveTracks();

        List<Track> GetTracks();

        Track FindTrack(int id);

        void DeleteTrack(int id);

        void AddTrack(Track track);

        void ChangeTrack();
    }
}
