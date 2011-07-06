using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Machine.Specifications;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfDateTime
{
    [Subject(typeof(FluentJdf.LinqToJdf.JdfDateTime))]
    public class when_converting_to_jdf_date_time_string {
        static DateTime dateTime = DateTime.Now;
        static DateTime dateTimeUtc = DateTime.UtcNow;
        static string dateTimeString;
        static string dateTimeUtcString;

        Because of = () => {
            dateTimeString = dateTime.ToJdfDateTimeString();
            dateTimeUtcString = dateTimeUtc.ToJdfDateTimeString();
        };

        It should_be_able_to_get_back_local_date_time_from_string = () => DateTime.Parse(dateTimeString, null, DateTimeStyles.RoundtripKind).ShouldEqual(dateTime);

        It should_be_able_to_get_back_utc_date_time_from_string = () => DateTime.Parse(dateTimeUtcString, null, DateTimeStyles.RoundtripKind).ShouldEqual(dateTimeUtc);

        It should_be_able_to_get_back_utc_date_time_from_string_with_kind_utc = () => DateTime.Parse(dateTimeUtcString, null, DateTimeStyles.RoundtripKind).Kind.ShouldEqual(DateTimeKind.Utc);

        It should_be_able_to_get_back_local_date_time_from_string_with_kind_local = () => DateTime.Parse(dateTimeString, null, DateTimeStyles.RoundtripKind).Kind.ShouldEqual(DateTimeKind.Local);
    }
}
