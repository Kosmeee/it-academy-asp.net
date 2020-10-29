using ItAcademy.Project.Music.Domain.Models.Identity;

namespace ItAcademy.Project.Music.Domain.DomainServices.Interfaces
{
   public interface IAppUserDomainService
    {
        int GetPlaylistId(ApplicationUser appUser);
    }
}
