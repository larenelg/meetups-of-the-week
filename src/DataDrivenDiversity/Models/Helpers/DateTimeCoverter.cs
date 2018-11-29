using System;

namespace DataDrivenDiversity.Models.Helpers
{
    public static class DateTimeCoverter
    {
        public static DateTime EpochToDateTime(long unixTimestampMilliseconds, long offsetMilliseconds)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(unixTimestampMilliseconds + offsetMilliseconds);
        }
    }
}