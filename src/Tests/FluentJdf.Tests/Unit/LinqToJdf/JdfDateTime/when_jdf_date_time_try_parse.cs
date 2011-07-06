using System;
using FluentJdf.LinqToJdf;
using Machine.Specifications;

namespace FluentJdf.Tests.Unit.LinqToJdf.JdfDateTime {
    [Subject(typeof(FluentJdf.LinqToJdf.JdfDateTime))]
    public class when_jdf_date_time_try_parse {
        static DateTime dateTime = DateTime.Now;
        static DateTime dateTimeUtc = DateTime.UtcNow;
        static string dateTimeString;
        static string dateTimeUtcString;

        Because of = () => {
            dateTimeString = dateTime.ToJdfDateTimeString();
            dateTimeUtcString = dateTimeUtc.ToJdfDateTimeString();
        };

        It should_work_for_local_date_time_string = () => {
            DateTime outDateTime;
            FluentJdf.LinqToJdf.JdfDateTime.TryParse(dateTimeString, out outDateTime).ShouldBeTrue();
            outDateTime.ShouldEqual(dateTime);
            outDateTime.Kind.ShouldEqual(DateTimeKind.Local);
        };

        It should_work_for_utc_date_time_string = () =>
        {
            DateTime outDateTime;
            FluentJdf.LinqToJdf.JdfDateTime.TryParse(dateTimeUtcString, out outDateTime).ShouldBeTrue();
            outDateTime.ShouldEqual(dateTimeUtc);
            outDateTime.Kind.ShouldEqual(DateTimeKind.Utc);
        };

        It should_throw_argument_null_exception_if_string_to_parse_is_null = () =>
        {
            DateTime outDateTime;
            Catch.Exception(() => FluentJdf.LinqToJdf.JdfDateTime.TryParse(null, out outDateTime).ShouldBeTrue()).ShouldNotBeOfType(typeof(ArgumentNullException));
        };

        It should_throw_format_exception_if_string_to_parse_is_invalid = () =>
        {
            DateTime outDateTime;
            Catch.Exception(() => FluentJdf.LinqToJdf.JdfDateTime.TryParse("dogs and cats", out outDateTime).ShouldBeTrue()).ShouldNotBeOfType(typeof(FormatException));
        };
    }
}