using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Domain.DomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrackDomainService(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            this.trackRepository = trackRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddTrack(Track track)
        {
            trackRepository.Add(track);
            unitOfWork.SaveChanges();
        }

        public void ChangeTrack()
        {
            unitOfWork.SaveChanges();
        }

        public void DeleteTrack(int id)
        {
            trackRepository.DeleteById(id);
            unitOfWork.SaveChanges();
        }

        public Track FindTrack(int id)
        {
           return trackRepository.FindTrack(id);
        }

        public List<Track> GetFiveTracks()
        {
            return trackRepository.GetFiveTracks();
        }

        public List<Track> GetTracks()
        {
            return trackRepository.GetAllWithAllAttachments();
        }
    }
}
