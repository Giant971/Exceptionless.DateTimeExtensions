using System;
using System.Text.RegularExpressions;

namespace Exceptionless.DateTimeExtensions.FormatParsers {
    [Priority(80)]
    public class YearFormatParser : IFormatParser {
        private static readonly Regex _parser = new Regex(@"^\s*(?<year>\d{4})\s*$");

        public DateTimeRange Parse(string content, DateTime now) {
            var m = _parser.Match(content);
            if (!m.Success)
                return null;

            int year = Int32.Parse(m.Groups["year"].Value);
            return new DateTimeRange(now.ChangeYear(year).StartOfYear(), now.ChangeYear(year).EndOfYear());
        }
    }
}