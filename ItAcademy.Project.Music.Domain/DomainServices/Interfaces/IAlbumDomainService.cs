using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.DomainServices.Interfaces
{
    public interface IAlbumDomainService
    {
        Album Get(int id);
    }
}
