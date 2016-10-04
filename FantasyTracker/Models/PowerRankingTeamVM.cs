using FantasyTracker.Logic.Enums;

namespace FantasyTracker.Web.Models
{
    public class PowerRankingTeamVM
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string PageUrl { get; set; }
        public string Record { get; set; }
        public RankChange RankChange { get; set; }
        public int NumberOfRanksChanged { get; set; }
        public string RankLastWeek { get; set; }
        public string Comments { get; set; }
    }
}