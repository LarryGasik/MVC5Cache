using System;
using System.Web.Mvc;
using CachingExample.ViewModels.Home;

namespace CachingExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CachingExample.ViewModels.Home.IndexViewModel model = new IndexViewModel();
            model.FormattedCurrency = (3.5).ToString("C");
            model.FormattedTime = DateTime.Now.ToString();
            return View(model);
        }
    }
}
