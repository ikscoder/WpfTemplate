﻿using System;

namespace Wpf_Template
{
    public static class UnixTimeExtension
    {
        private static readonly DateTime UnixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        ///   Convert a long into a DateTime
        /// </summary>
        public static DateTime FromUnixTime(this long unixTime)
            => UnixStart.AddSeconds(unixTime > 0 ? unixTime : 0).ToLocalTime();

        /// <summary>
        ///   Convert a DateTime into a long
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static long ToUnixTime(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
                return 0;

            var utcDateTime = dateTime.ToUniversalTime();

            double delta = (utcDateTime - UnixStart).TotalSeconds;

            if (delta < 0)
                throw new ArgumentOutOfRangeException(nameof(dateTime), @"Unix epoch starts January 1st, 1970");

            return Convert.ToInt64(delta);
        }
    }
}
