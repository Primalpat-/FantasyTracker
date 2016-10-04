using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FantasyTracker.Data.Models.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Games");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.Team1Id).HasColumnName("Team1Id");
            this.Property(t => t.Team1Score).HasColumnName("Team1Score");
            this.Property(t => t.Team2Id).HasColumnName("Team2Id");
            this.Property(t => t.Team2Score).HasColumnName("Team2Score");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.Games)
                .HasForeignKey(d => d.Team1Id);
            this.HasRequired(t => t.Team1)
                .WithMany(t => t.Games1)
                .HasForeignKey(d => d.Team2Id);
            this.HasRequired(t => t.Week)
                .WithMany(t => t.Games)
                .HasForeignKey(d => d.WeekId);

        }
    }
}
