using FluentJdf.Configuration;
using Machine.Specifications;
using Rhino.Mocks;

namespace FluentJdf.Tests.Unit.Configuration.JdfAuthoringSettingsBuilder {
    [Subject(typeof(FluentJdf.Configuration.JdfAuthoringSettingsBuilder))]
    public class when_setting_sender_id_to_whitespace {
        static FluentJdf.Configuration.JdfAuthoringSettingsBuilder builder;
        static FluentJdf.Configuration.JdfAuthoringSettings settings;

        Establish context = () => {
            settings = new JdfAuthoringSettings();
            builder = new FluentJdf.Configuration.JdfAuthoringSettingsBuilder(MockRepository.GenerateStub<IFluentJdfLibrary>(),
                                                                              settings);
        };

        Because of = () => builder.SenderId("    ");

        It should_have_sender_id_null_in_settings = () => settings.SenderId.ShouldBeNull();
    }
}