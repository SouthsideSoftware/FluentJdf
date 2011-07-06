using System;
using System.Globalization;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfDateTime {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfDateTime))]
    public class when_parsing_jdf_date_time_strings {
        static DateTime dateTime = DateTime.Now;
        static DateTime dateTimeUtc = DateTime.UtcNow;
        static string dateTimeString;
        static string dateTimeUtcString;

        Because of = () => {
            dateTimeString = dateTime.ToJdfDateTimeString();
            dateTimeUtcString = dateTimeUtc.ToJdfDateTimeString();
        };

        It should_be_able_to_get_back_local_date_time_from_string = () => FluentJdf.LinqToJdf.JdfDateTime.Parse(dateTimeString).ShouldEqual(dateTime);

        It should_be_able_to_get_back_utc_date_time_from_string = () => FluentJdf.LinqToJdf.JdfDateTime.Parse(dateTimeUtcString).ShouldEqual(dateTimeUtc);

        It should_be_able_to_get_back_utc_date_time_from_string_with_kind_utc = () => FluentJdf.LinqToJdf.JdfDateTime.Parse(dateTimeUtcString).Kind.ShouldEqual(DateTimeKind.Utc);

        It should_be_able_to_get_back_local_date_time_from_string_with_kind_local = () => FluentJdf.LinqToJdf.JdfDateTime.Parse(dateTimeString).Kind.ShouldEqual(DateTimeKind.Local);
    }
}