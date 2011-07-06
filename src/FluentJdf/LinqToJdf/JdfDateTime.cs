using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Extensions for working with JDF date time.
    /// </summary>
    public static class JdfDateTime
    {
        /// <summary>
        /// Converts the date time to a string value suitable for use in 
        /// a JDF date time attribute.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToJdfDateTimeString(this DateTime dateTime) {
            return dateTime.ToString("O");
        }

        /// <summary>
        /// Tries to parse a string containing a JDF date time into a
        /// date time.  If the conversion fails, returns <see langword="false"/>.  If the conversion
        /// succeeds, returns <see langword="true"/> and the out variable contains the date time value.
        /// </summary>
        /// <param name="jdfDateTime"></param>
        /// <param name="parsedDateTime"></param>
        /// <returns></returns>
        public static bool TryParse(string jdfDateTime, out DateTime parsedDateTime) {
            parsedDateTime = DateTime.MinValue;
            DateTime dt;
            if (jdfDateTime != null && DateTime.TryParse(jdfDateTime, null, DateTimeStyles.RoundtripKind, out dt))
            {
                parsedDateTime = dt;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Parses a string to a JDF date time.
        /// </summary>
        /// <param name="jdfDateTime"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If the given jdf date time string is null.</exception>
        /// <exception cref="FormatException">If the given jdf date time string is not a valid date time representation.</exception>
        public static DateTime Parse(string jdfDateTime) {
            return DateTime.Parse(jdfDateTime, null, DateTimeStyles.RoundtripKind);
        }
    }
}
