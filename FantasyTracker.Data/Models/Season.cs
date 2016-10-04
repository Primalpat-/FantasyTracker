using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class Season
    {
        public Season()
        {
            this.Teams = new List<Team>();
            this.Leagues = new List<League>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
