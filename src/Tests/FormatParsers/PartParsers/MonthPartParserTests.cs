using System;
using System.Collections.Generic;
using Exceptionless.DateTimeExtensions.FormatParsers.PartParsers;
using Xunit;

namespace Exceptionless.DateTimeExtensions.Tests.FormatParsers.PartParsers {
    public class MonthPartParserTests : PartParserTestsBase {
        [Theory]
        [MemberData("Inputs")]
        public void ParseInput(string input, bool isUpperLimit, DateTime? expected) {
            ValidateInput(new MonthPartParser(), input, isUpperLimit, expected);
        }

        public static IEnumerable<object[]> Inputs {
            get {
                return new[] {
                    new object[] { "jan",       false, _now.ChangeMonth(1).StartOfMonth() },
                    new object[] { "jan",       true,  _now.ChangeMonth(1).EndOfMonth() },
                    new object[] { "nov",       false, _now.StartOfMonth() },
                    new object[] { "nov",       true,  _now.EndOfMonth() },
                    new object[] { "decemBer",  false, _now.ChangeMonth(12).StartOfMonth() },
                    new object[] { "dec",       true,  _now.ChangeMonth(12).EndOfMonth() },
                    new object[] { "blah",      false, null },
                    new object[] { "blah blah", true,  null }
                };
            }
        }
    }
}
