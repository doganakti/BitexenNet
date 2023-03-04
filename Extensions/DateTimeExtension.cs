using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitexenNet;
internal static class DateTimeExtension
{
    static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long ConvertToTimeStamp(this DateTime date)
    {
        try
        {
            date = date.ToUniversalTime();
            TimeSpan elapsedTime = date - Epoch;
            return (long)elapsedTime.TotalMilliseconds;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return 0;
        }
    }

    public static DateTime ConvertToDateTime(this long unixTimeStamp)
    {
        try
        {
            if (unixTimeStamp.ToString().Length == 10)
            {
                unixTimeStamp = unixTimeStamp * 1000;
            }
            DateTime datetime = Epoch.AddMilliseconds(unixTimeStamp).ToLocalTime();
            datetime = datetime.ToUniversalTime();
            return datetime;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Epoch;
        }
    }
}

