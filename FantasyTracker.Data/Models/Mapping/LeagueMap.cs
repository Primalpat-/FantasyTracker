using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FantasyTracker.Data.Models.Mapping
{
    public class LeagueMap : EntityTypeConfiguration<League>
    {
        public LeagueMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Leagues");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasMany(t => t.Seasons)
                .WithMany(t => t.Leagues)
                .Map(m =>
                    {
                        m.ToTable("LeagueSeasons");
                        m.MapLeftKey("LeagueId");
                        m.MapRightKey("SeasonId");
                    });


        }
    }
}
