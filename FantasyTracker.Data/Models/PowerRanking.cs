using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class PowerRanking
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int WeekId { get; set; }
        public int Rank { get; set; }
        public string Comments { get; set; }
        public virtual Team Team { get; set; }
        public virtual Week Week { get; set; }
    }
}
