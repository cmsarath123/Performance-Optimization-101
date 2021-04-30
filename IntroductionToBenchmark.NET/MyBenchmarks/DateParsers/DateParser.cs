using System;

namespace IntroductionToBenchmark.NET.MyBenchmarks.DateParsers
{
    // "2021-04-28T16:33:06Z"
    public class DateParser
    {
        public int GetYearFromDateTime(string DateTimeAsString)
        {
            var dateTime = DateTime.Parse(DateTimeAsString);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string DateTimeAsString)
        {
            var _data = DateTimeAsString.Split('-');
            return int.Parse(_data[0]);
        }

        public int GetYearFromSubstring(string DateTimeAsString)
        {
            var _indexOfHyphen = DateTimeAsString.IndexOf('-');
            return int.Parse(DateTimeAsString.Substring(0, _indexOfHyphen));
        }

        public int GetYearFromSpan(ReadOnlySpan<char> DateTimeAsString)
        {
            var _indexOfHyphen = DateTimeAsString.IndexOf('-');
            return int.Parse(DateTimeAsString.Slice(0, _indexOfHyphen));
        }

        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> DateTimeAsString)
        {
            var _indexOfHyphen = DateTimeAsString.IndexOf('-');
            var yearAsSpan = DateTimeAsString.Slice(0, _indexOfHyphen);
            var temp = 0;
            for(int i = 0; i< yearAsSpan.Length; i++)
            {
                temp = temp * 10 + (yearAsSpan[i] - '0');
            }
            return temp;
        }
    }
}
