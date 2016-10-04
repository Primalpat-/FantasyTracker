using FantasyTracker.Logic.Enums;

namespace FantasyTracker.Logic.Services.Rank
{
    public static class RankChangeService
    {
        public static RankChange DetermineRankChange(int rankThisWeek, int rankLastWeek)
        {
            if (rankThisWeek < rankLastWeek)
                return RankChange.Increased;

            if (rankThisWeek > rankLastWeek)
                return RankChange.Decreased;

            return RankChange.NoChange;
        }
    }
}
