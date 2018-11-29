using System;
using DataDrivenDiversity.Models.Helpers;
using Xunit;

namespace DataDrivenDiversity.Tests
{
    public class DateTimeHelperTests
    {
        [Fact]
        public void ShouldConvertToCorrectDateTime()
        {
            Assert.Equal("2018-11-28 18:00:00", DateTimeCoverter.EpochToDateTime(1543392000000, 36000000).ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}