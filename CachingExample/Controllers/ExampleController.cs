﻿using System;
using System.Web.Http;
using System.Web.Mvc;

namespace CachingExample.Controllers
{
    public class ExampleController : ApiController
    {
        /// <summary>
        /// We're going to just do some basic caching here.
        /// </summary>
        /// <param name="id">Some ID</param>
        /// <returns>A string with a date time in it, indicating when it was calculated.</returns>
        
        //I'll be damned. You cannot put a cache on a webAPI with out of the box MVC.
        [System.Web.Http.HttpGet]
        public string GetACurrencyValue(int id)
        {
            string money = id.ToString("C0");
            string time = DateTime.Now.ToString();
            string returnValue = $"I need about {money} generated at {time}";
            return returnValue;
        }
    }
}
