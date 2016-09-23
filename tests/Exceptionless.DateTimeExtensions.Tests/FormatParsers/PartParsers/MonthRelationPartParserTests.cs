using System;
using System.Collections.Generic;
using Exceptionless.DateTimeExtensions.FormatParsers.PartParsers;
using Xunit;

namespace Exceptionless.DateTimeExtensions.Tests.FormatParsers.PartParsers {
    public class MonthRelationPartParserTests : PartParserTestsBase {
        [Theory]
        [MemberData("Inputs")]
        public void ParseInput(string input, bool isUpperLimit, DateTime? expected) {
            ValidateInput(new MonthRelationPartParser(), input, isUpperLimit, expected);
        }

        public static IEnumerable<object[]> Inputs {
            get {
                return new[] {
                    new object[] { "this jan",      false, _now.AddYears(1).ChangeMonth(1).StartOfMonth() },
                    new object[] { "this janUary",  true,  _now.AddYears(1).ChangeMonth(1).EndOfMonth() },
                    new object[] { "last jan",      false, _now.ChangeMonth(1).StartOfMonth() },
                    new object[] { "last jan",      true,  _now.ChangeMonth(1).EndOfMonth() },
                    new object[] { "next januaRY",  false, _now.AddYears(1).ChangeMonth(1).StartOfMonth() },
                    new object[] { "next jan",      true,  _now.AddYears(1).ChangeMonth(1).EndOfMonth() },
                    new object[] { "this november", false, _now.StartOfMonth() },
                    new object[] { "this november", true,  _now.EndOfMonth() },
                    new object[] { "next november", false, _now.AddYears(1).StartOfMonth() },
                    new object[] { "next november", true,  _now.AddYears(1).EndOfMonth() },
                    new object[] { "this december", true,  _now.ChangeMonth(12).EndOfMonth() },
                    new object[] { "last november", false, _now.SubtractYears(1).StartOfMonth() },
                    new object[] { "blah",          false, null },
                    new object[] { "blah blah",     true,  null }
                };
            }
        }
    }
}
