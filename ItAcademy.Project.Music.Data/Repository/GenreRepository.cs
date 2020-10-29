using ItAcademy.Project.Music.Domain.Models;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Data.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public GenreRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
