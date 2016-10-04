using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int Team1Id { get; set; }
        public decimal Team1Score { get; set; }
        public int Team2Id { get; set; }
        public decimal Team2Score { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Week Week { get; set; }
    }
}
