using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Helpers
{
    public static class Helper
    {

        public static DateTime kuwaitTimeNow()
        {
            var info = TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time");

            DateTime localServerTime = DateTime.UtcNow;

            DateTime localTime = TimeZoneInfo.ConvertTime(localServerTime, info);

            return localTime;
        }

    }
}
