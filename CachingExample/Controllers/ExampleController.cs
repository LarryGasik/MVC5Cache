using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CachingExample.Controllers
{
    public class ExampleController : ApiController
    {
        /// <summary>
        /// We're going to just do some basic caching here.
        /// </summary>
        /// <param name="id">Some ID</param>
        /// <returns>A string with a date time in it, indicating when it was calculated.</returns>
        [HttpGet]
        public string GetACurrencyValue(int id)
        {
            string money = id.ToString("C0");
            string time = DateTime.Now.ToString();
            string returnValue = $"I need about {money} generated at {time}";
            return returnValue;
        }
    }
}
