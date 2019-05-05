using System.Globalization;

namespace CachingExample.Services
{
    public interface ICultureInfoService
    {
        CultureInfo GetCultureInfo(string[] userLanguages);
    }
}