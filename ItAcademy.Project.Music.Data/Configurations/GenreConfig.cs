using System.Data.Entity.ModelConfiguration;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Data.Configurations
{
   public class GenreConfig : EntityTypeConfiguration<Genre>
    {
        public GenreConfig()
        {
            ToTable("Genres");
            Property(c => c.Title).IsRequired();
            HasKey(c => c.Id);
        }
    }
}
