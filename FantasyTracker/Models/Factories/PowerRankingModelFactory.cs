using System;
using System.Collections.Generic;
using System.Linq;
using FantasyTracker.Data.Models;
using FantasyTracker.Logic.Extensions.Integers;
using FantasyTracker.Logic.Services.Rank;
using FantasyTracker.Logic.Services.Record;

namespace FantasyTracker.Web.Models.Factories
{
    public class PowerRankingModelFactory
    {
        public PowerRankingVM GetModel(int leagueId, int weekId)
        {
            var model = new PowerRankingVM();

            model.ChartModel = GetChartModel(leagueId, weekId);

            return model;
        }

        private PowerRankingChartVM GetChartModel(int leagueId, int weekNumber)
        {
            var db = new FantasyTrackerContext();
            var model = new PowerRankingChartVM();

            var league = db.Leagues.Find(leagueId);
            var season = league.Seasons.OrderByDescending(s => s.Id).First();
            var week = db.Weeks.Find(weekNumber);

            model.Season = season.Name;
            model.Week = week.Name;
            model.Teams = GetTeamModels(league, week);

            return model;
        }

        private List<PowerRankingTeamVM> GetTeamModels(League league, Week week)
        {
            var models = new List<PowerRankingTeamVM>();

            foreach (var team in league.Teams)
            {
                var model = new PowerRankingTeamVM();
                var rankThisWeek = team.PowerRankings.First(p => p.WeekId == week.Id);
                var rankLastWeek = team.PowerRankings.First(p => p.WeekId == (week.Id - 1));
                
                model.Name = team.Name;
                model.ImageUrl = team.ImageUrl;
                model.PageUrl = team.PageUrl;
                model.Record = TeamRecordService.DetermineRecord(team);
                model.Rank = rankThisWeek.Rank;
                model.Comments = rankThisWeek.Comments;
                model.RankLastWeek = rankLastWeek.Rank.ToOrdinal();
                model.NumberOfRanksChanged = Math.Abs(rankThisWeek.Rank - rankLastWeek.Rank);
                model.RankChange = RankChangeService.DetermineRankChange(rankThisWeek.Rank, rankLastWeek.Rank);

                models.Add(model);
            }

            return models.OrderBy(m => m.Rank).ToList();
        }
    }
}