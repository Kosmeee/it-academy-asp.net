using System.Data.Entity.ModelConfiguration;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Data.Configurations
{
   public class AlbumConfig : EntityTypeConfiguration<Album>
    {
        public AlbumConfig()
        {
            ToTable("Albums");
            Property(c => c.Title).IsRequired();
            HasKey(c => c.Id);
            HasRequired(c => c.Artist)
                .WithMany(c => c.Albums)
                .Map(c => c.MapKey("ArtistId"))
                .WillCascadeOnDelete(false);
        }
    }
}
