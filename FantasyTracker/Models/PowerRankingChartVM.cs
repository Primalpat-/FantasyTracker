using System.Collections.Generic;

namespace FantasyTracker.Web.Models
{
    public class PowerRankingChartVM
    {
        public string Season { get; set; }
        public string Week { get; set; }
        public List<PowerRankingTeamVM> Teams { get; set; }
    }
}