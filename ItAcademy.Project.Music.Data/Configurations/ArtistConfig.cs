using System.Data.Entity.ModelConfiguration;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Data.Configurations
{
    public class ArtistConfig : EntityTypeConfiguration<Artist>
    {
        public ArtistConfig()
        {
            ToTable("Artists");
            Property(c => c.Nickname).IsRequired();
            HasKey(c => c.Id);
            HasOptional(c => c.Genre)
                .WithMany(c => c.Artists)
                .Map(c => c.MapKey("GenreId"))
                .WillCascadeOnDelete(false);
        }
    }
}
