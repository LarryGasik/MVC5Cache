using System;
using System.Globalization;
using System.Web.Mvc;
using CachingExample.Services;
using CachingExample.ViewModels.Home;

namespace CachingExample.Controllers
{
    /// <summary>
    /// Larry Sample Summary
    /// </summary>
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

        /// <summary>
        /// This Caching is configured right here.
        /// Every different value for id will be cached.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 60, VaryByParam = "id")]
        public ViewResult ProductDetail(int id)
        {
            IndexViewModel model = new IndexViewModel();
            CultureInfo culture = _cultureInfoService.GetCultureInfo(Request.UserLanguages);
            model.FormattedCurrency = id.ToString("C", culture);
            model.FormattedTime = _timeService.DateTimeNow().ToString();
            return View(model);
        }

        /// <summary>
        /// This is custom Caching. Inside the Global.asax file, there's a
        /// method that will take the HTTP request, and you can build your
        /// own custom caching method.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration=60, VaryByCustom = "Language")]
        public ViewResult ByLanguage()
        {
            IndexViewModel model = new IndexViewModel();
            CultureInfo culture = _cultureInfoService.GetCultureInfo(Request.UserLanguages);
            model.FormattedCurrency = (3.5).ToString("C", culture);
            model.FormattedTime = _timeService.DateTimeNow().ToString(culture);
            return View(model);
        }


    }
}
