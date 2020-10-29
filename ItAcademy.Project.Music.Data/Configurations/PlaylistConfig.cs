using System.Data.Entity.ModelConfiguration;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Data.Configurations
{
   public class PlaylistConfig : EntityTypeConfiguration<Playlist>
    {
        public PlaylistConfig()
        {
            ToTable("Playlists");
            Property(c => c.Title).IsRequired();
            HasKey(c => c.Id);
            HasMany(c => c.Tracks)
               .WithMany(c => c.Playlists)
               .Map(cs =>
               {
                   cs.MapLeftKey("PlaylistId");
                   cs.MapRightKey("TrackId");
                   cs.ToTable("PlaylistTrack");
               });
        }
    }
}
