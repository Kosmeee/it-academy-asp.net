using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Models.Identity;
using ItAcademy.Project.Music.Domain.Repositories;

namespace ItAcademy.Project.Music.Domain.DomainServices
{
    public class AppUserDomainService : IAppUserDomainService
    {
        private readonly IAppUserRepository appUserRepository;

        public AppUserDomainService(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }

        public int GetPlaylistId(ApplicationUser appUser)
        {
           return appUserRepository.GetPlaylistId(appUser);
        }
    }
}
