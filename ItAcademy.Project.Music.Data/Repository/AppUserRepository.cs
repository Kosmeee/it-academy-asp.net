using ItAcademy.Project.Music.Domain.Models.Identity;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Data.Repository
{
    public class AppUserRepository : BaseRepository<ApplicationUser>, IAppUserRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public AppUserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int GetPlaylistId(ApplicationUser appUser)
        {
            return appUser.Playlist.Id;
        }
    }
}
