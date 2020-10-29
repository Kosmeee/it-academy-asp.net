using System.Data.Entity.ModelConfiguration;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Data.Configurations
{
   public class TrackConfig : EntityTypeConfiguration<Track>
    {
        public TrackConfig()
        {
            ToTable("Tracks");
            Property(c => c.Title).IsRequired();
            HasKey(c => c.Id);

            HasOptional(c => c.Artist)
                .WithMany(c => c.Tracks)
                .Map(c => c.MapKey("ArtistId"))
                .WillCascadeOnDelete(true);

            HasOptional(c => c.Album)
                .WithMany(c => c.Tracks)
                .Map(c => c.MapKey("AlbumId"))
                .WillCascadeOnDelete(true);

            HasOptional(c => c.Genre)
                .WithMany(c => c.Tracks)
                .Map(c => c.MapKey("GenreId"))
                .WillCascadeOnDelete(false);
        }
    }
}
