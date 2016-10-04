using System.IO;
using System.Web.Mvc;

namespace FantasyTracker.Logic.Extensions.Controllers
{
    public static class ViewToStringExtension
    {
        public static string ViewToString(this Controller controller, string viewName, object model)
        {
            return ViewToString(controller, viewName, new ViewDataDictionary(model));
        }

        public static string ViewToString(this Controller controller, string viewName, ViewDataDictionary viewData)
        {
            var controllerContext = controller.ControllerContext;
            var viewResult = ViewEngines.Engines.FindView(controllerContext, viewName, null);
            StringWriter writer;

            using (writer = new StringWriter())
            {
                var viewContext = new ViewContext(controllerContext, viewResult.View, viewData, controllerContext.Controller.TempData, writer);
                viewResult.View.Render(viewContext, writer);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
            }

            return writer.ToString();
        }

        public static string PartialViewToString(this Controller controller, string viewName, object model)
        {
            return PartialViewToString(controller, viewName, new ViewDataDictionary(model));
        }

        public static string PartialViewToString(this Controller controller, string viewName, ViewDataDictionary viewData)
        {
            var controllerContext = controller.ControllerContext;
            var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
            StringWriter writer;

            using (writer = new StringWriter())
            {
                var viewContext = new ViewContext(controllerContext, viewResult.View, viewData, controllerContext.Controller.TempData, writer);
                viewResult.View.Render(viewContext, writer);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
            }

            return writer.ToString();
        }
    }
}
