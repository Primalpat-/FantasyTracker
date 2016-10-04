using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FantasyTracker.Data.Models.Mapping;

namespace FantasyTracker.Data.Models
{
    public partial class FantasyTrackerContext : DbContext
    {
        static FantasyTrackerContext()
        {
            Database.SetInitializer<FantasyTrackerContext>(null);
        }

        public FantasyTrackerContext()
            : base("Name=FantasyTrackerContext")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PowerRanking> PowerRankings { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Week> Weeks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new LeagueMap());
            modelBuilder.Configurations.Add(new ManagerMap());
            modelBuilder.Configurations.Add(new PowerRankingMap());
            modelBuilder.Configurations.Add(new SeasonMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new WeekMap());
        }
    }
}
