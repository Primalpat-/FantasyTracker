using FantasyTracker.Data.Models;
using System.Linq;

namespace FantasyTracker.Logic.Services.Record
{
    public static class TeamRecordService
    {
        public static string DetermineRecord(Team team)
        {
            var wins = GetTeamWins(team);
            var losses = GetTeamLosses(team);
            var ties = GetTeamTies(team);

            return ties > 0 ? $"{wins}-{losses}-{ties}" : $"{wins}-{losses}";
        }

        public static int GetTeamWins(Team team)
        {
            var games = team.Games.Concat(team.Games1);
            return games.Count(g => (g.Team1Id == team.Id &&
                                     g.Team1Score > g.Team2Score) ||
                                    (g.Team2Id == team.Id &&
                                     g.Team2Score > g.Team1Score));
        }

        public static int GetTeamLosses(Team team)
        {
            var games = team.Games.Concat(team.Games1);
            return games.Count(g => (g.Team1Id == team.Id &&
                                     g.Team1Score < g.Team2Score) ||
                                    (g.Team2Id == team.Id &&
                                     g.Team2Score < g.Team1Score));
        }

        public static int GetTeamTies(Team team)
        {
            var games = team.Games.Concat(team.Games1);
            return games.Count(g => (g.Team1Id == team.Id &&
                                     g.Team1Score == g.Team2Score) ||
                                    (g.Team2Id == team.Id &&
                                     g.Team2Score == g.Team1Score));
        }
    }
}
