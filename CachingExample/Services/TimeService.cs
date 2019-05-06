using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CachingExample.Services
{
    public class TimeService:ITimeService
    {
        public DateTime DateTimeNow()
        {
            return DateTime.Now;
        }
    }
}