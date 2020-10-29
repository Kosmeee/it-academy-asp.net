using ItAcademy.Project.Music.Domain.Models.Identity;

namespace ItAcademy.Project.Music.Domain.Repositories
{
    public interface IAppUserRepository : IBaseRepository<ApplicationUser>
    {
        int GetPlaylistId(ApplicationUser appUser);
    }
}
