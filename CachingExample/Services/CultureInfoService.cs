using System;
using System.Globalization;

namespace CachingExample.Services
{
    public class CultureInfoService:ICultureInfoService
    {
        public CultureInfo GetCultureInfo(string[] userLanguages)
        {
            CultureInfo culture = null;

            foreach (string language in userLanguages)
            {
                try
                {
                    culture = new CultureInfo(language);
                    break;
                }
                catch (CultureNotFoundException e)
                {
                    //Todo: Log this. Maybe we can add a new culture type.
                }
            }
            
            //No viable Culture found from the browser
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            return culture;
        }
    }
}