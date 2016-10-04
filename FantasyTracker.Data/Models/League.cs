using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class League
    {
        public League()
        {
            this.Teams = new List<Team>();
            this.Seasons = new List<Season>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
    }
}
