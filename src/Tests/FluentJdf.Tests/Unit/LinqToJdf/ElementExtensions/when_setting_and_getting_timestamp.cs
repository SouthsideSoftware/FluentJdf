using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Machine.Specifications;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Tests.Unit.LinqToJdf.ElementExtensions
{
    [Subject(typeof(FluentJdf.LinqToJdf.ElementExtensions))]
    public class when_setting_and_getting_timestamp {
        static XElement element;

        Establish context = () => element = new XElement("Foo");

        It should_be_able_to_set_utc_now_and_get_back = () => {
            var dateTime = DateTime.UtcNow;
            element.SetTimeStamp(dateTime);
            element.GetTimeStamp().ShouldEqual(dateTime);
        };

        It should_have_kind_utc_after_set_from_utc_now = () => {
            element.SetTimeStampToUtcNow();
            element.GetTimeStamp().Value.Kind.ShouldEqual(DateTimeKind.Utc);
        };

        It should_be_able_to_set_local_now_and_get_back = () =>
        {
            var dateTime = DateTime.Now;
            element.SetTimeStamp(dateTime);
            element.GetTimeStamp().ShouldEqual(dateTime);
        };

        It should_be_able_to_set_local_and_get_back_local_kind = () =>
        {
            var dateTime = DateTime.Now;
            element.SetTimeStamp(dateTime);
            element.GetTimeStamp().Value.Kind.ShouldEqual(DateTimeKind.Local);
        };

        It should_get_null_when_timestamp_not_set = () =>
        {
            element.SetAttributeValue("TimeStamp", null);
            element.GetTimeStamp().ShouldBeNull();
        };
    }
}
