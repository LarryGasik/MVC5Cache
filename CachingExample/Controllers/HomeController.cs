using System;
using System.Globalization;
using System.Web.Mvc;
using CachingExample.Services;
using CachingExample.ViewModels.Home;

namespace CachingExample.Controllers
{
    
    public class HomeController : Controller
    {
        private ITimeService _timeService;

        public HomeController() : this(new TimeService())
        {

        }
        public HomeController(ITimeService timeService)
        {
            _timeService = timeService;
        }


        /// <summary>
        /// This CacheProfile comes from the config.
        /// </summary>
        /// <returns></returns>
        [OutputCache(CacheProfile = "Rarely")]
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            //Todo: We need to figure out how to generate a cultureInfo when
            //      the server does not have said language. We need to make
            //      sure that we loop through each of the languages as well.
            CultureInfo culture = new CultureInfo(Request.UserLanguages[0]);
            model.FormattedCurrency = (3.5).ToString("C", culture);

            model.FormattedCurrency = (3.5).ToString("C");
            model.FormattedTime = _timeService.DateTimeNow().ToString();
            return View(model);
        }

        /// <summary>
        /// This CacheProfile comes from the config.
        /// </summary>
        /// <returns></returns>
        [OutputCache(CacheProfile = "Frequently")]
        public ActionResult Product()
        {


            IndexViewModel model = new IndexViewModel();
            CultureInfo culture = new CultureInfo(Request.UserLanguages[0]);
            model.FormattedCurrency = (3.5).ToString("C", culture);
            model.FormattedTime = _timeService.DateTimeNow().ToString();
            return View(model);
        }


    }
}
