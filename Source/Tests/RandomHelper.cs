﻿using System;

namespace Exceptionless.DateTimeExtensions.Tests {
    public static class RandomHelper {
        static readonly Random _rnd = new Random();

        public static DateTime GetRandomDate(DateTime from, DateTime to) {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(_rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
