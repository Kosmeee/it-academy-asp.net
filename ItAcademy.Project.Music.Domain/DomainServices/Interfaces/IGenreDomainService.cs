using System.Collections.Generic;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Domain.DomainServices.Interfaces
{
    public interface IGenreDomainService
    {
        Genre Get(int id);

        List<Genre> GetAll();
    }
}
