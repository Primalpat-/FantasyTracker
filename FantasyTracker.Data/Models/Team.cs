using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class Team
    {
        public Team()
        {
            this.Games = new List<Game>();
            this.Games1 = new List<Game>();
            this.PowerRankings = new List<PowerRanking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string PageUrl { get; set; }
        public int SeasonId { get; set; }
        public int LeagueId { get; set; }
        public int ManagerId { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Game> Games1 { get; set; }
        public virtual League League { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<PowerRanking> PowerRankings { get; set; }
        public virtual Season Season { get; set; }
    }
}
