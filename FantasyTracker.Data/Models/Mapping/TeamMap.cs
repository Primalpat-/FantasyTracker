using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FantasyTracker.Data.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ImageUrl)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.PageUrl)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Teams");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
            this.Property(t => t.PageUrl).HasColumnName("PageUrl");
            this.Property(t => t.SeasonId).HasColumnName("SeasonId");
            this.Property(t => t.LeagueId).HasColumnName("LeagueId");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");

            // Relationships
            this.HasRequired(t => t.League)
                .WithMany(t => t.Teams)
                .HasForeignKey(d => d.LeagueId);
            this.HasRequired(t => t.Manager)
                .WithMany(t => t.Teams)
                .HasForeignKey(d => d.ManagerId);
            this.HasRequired(t => t.Season)
                .WithMany(t => t.Teams)
                .HasForeignKey(d => d.SeasonId);

        }
    }
}
