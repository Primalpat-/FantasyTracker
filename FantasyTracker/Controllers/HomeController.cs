using System.Web.Mvc;
using FantasyTracker.Logic.Extensions.Controllers;
using FantasyTracker.Web.Models.Factories;

namespace FantasyTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PowerRankings(int leagueId, int weekId)
        {
            var factory = new PowerRankingModelFactory();
            var model = factory.GetModel(leagueId, weekId);
            var rawChartHtml = this.PartialViewToString("_PowerRankingChart", model.ChartModel);
            
            //Implement an HTML minifier
            model.ChartHtml = rawChartHtml;

            return View(model);
        }
    }
}