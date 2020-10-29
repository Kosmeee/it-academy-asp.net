using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Domain.DomainServices
{
    public class GenreDomainService : IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenreDomainService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            this.genreRepository = genreRepository;
            this.unitOfWork = unitOfWork;
        }

        public Genre Get(int id)
        {
            return genreRepository.Get(id);
        }

        public List<Genre> GetAll()
        {
            return genreRepository.GetAll();
        }
    }
}
