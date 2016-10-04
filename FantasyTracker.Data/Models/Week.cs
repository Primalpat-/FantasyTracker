using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class Week
    {
        public Week()
        {
            this.Games = new List<Game>();
            this.PowerRankings = new List<PowerRanking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<PowerRanking> PowerRankings { get; set; }
    }
}
