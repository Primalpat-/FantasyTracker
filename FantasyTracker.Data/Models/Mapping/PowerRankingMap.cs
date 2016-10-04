using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FantasyTracker.Data.Models.Mapping
{
    public class PowerRankingMap : EntityTypeConfiguration<PowerRanking>
    {
        public PowerRankingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comments)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PowerRankings");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.Comments).HasColumnName("Comments");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.PowerRankings)
                .HasForeignKey(d => d.TeamId);
            this.HasRequired(t => t.Week)
                .WithMany(t => t.PowerRankings)
                .HasForeignKey(d => d.WeekId);

        }
    }
}
