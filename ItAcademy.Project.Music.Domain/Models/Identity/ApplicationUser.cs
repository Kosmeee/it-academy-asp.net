using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.Project.Music.Domain.Models.Identity
{
   public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Playlist Playlist { get; set; }
    }
}
