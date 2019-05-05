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
        private ICultureInfoService _cultureInfoService;

        public HomeController() : this(new TimeService(), new CultureInfoService())
        {

        }
        public HomeController(ITimeService timeService, ICultureInfoService cultureInfoService)
        {
            _cultureInfoService = cultureInfoService;
            _timeService = timeService;
        }


        /// <summary>
        /// This CacheProfile comes from the config.
        /// </summary>
        /// <returns></returns>
        [OutputCache(CacheProfile = "Rarely")]
        public ViewResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            CultureInfo culture = _cultureInfoService.GetCultureInfo(Request.UserLanguages);
            model.FormattedCurrency = (3.5).ToString("C", culture);
            model.FormattedTime = _timeService.DateTimeNow().ToString(culture);
            return View(model);
        }

        /// <summary>
        /// This CacheProfile comes from the config.
        /// </summary>
        /// <returns></returns>
        [OutputCache(CacheProfile = "Frequently")]
        public ViewResult Product()
        {
            IndexViewModel model = new IndexViewModel();
            CultureInfo culture = _cultureInfoService.GetCultureInfo(Request.UserLanguages);
            model.FormattedCurrency = (3.5).ToString("C", culture);
            model.FormattedTime = _timeService.DateTimeNow().ToString();
            return View(model);
        }


    }
}
