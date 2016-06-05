﻿using System;
using System.Collections.Generic;
using Exceptionless.DateTimeExtensions.FormatParsers.PartParsers;
using Xunit;

namespace Exceptionless.DateTimeExtensions.Tests.FormatParsers.PartParsers {
    public class NamedDayPartParserTests : PartParserTestsBase {
        [Theory]
        [MemberData("Inputs")]
        public void ParseInput(string input, bool isUpperLimit, DateTime? expected) {
            ValidateInput(new NamedDayPartParser(), input, isUpperLimit, expected);
        }

        public static IEnumerable<object[]> Inputs {
            get {
                return new[] {
                    new object[] { "now",       false, _now },
                    new object[] { "now",       true,  _now },
                    new object[] { "yesterday", false, _now.SubtractDays(1).StartOfDay() },
                    new object[] { "yesterday", true,  _now.SubtractDays(1).EndOfDay() },
                    new object[] { "today",     false, _now.StartOfDay() },
                    new object[] { "today",     true,  _now.EndOfDay() },
                    new object[] { "tomorrow",  false, _now.AddDays(1).StartOfDay() },
                    new object[] { "tomorrow",  true,  _now.AddDays(1).EndOfDay() },
                    new object[] { "blah",      false, null },
                    new object[] { "blah blah", true,  null }
                };
            }
        }
    }
}
