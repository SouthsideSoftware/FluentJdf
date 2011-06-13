using Machine.Specifications;

namespace Infrastructure.Core.Tests.Unit.Helpers.ApplicationInformation
{
    [Subject(typeof(Core.Helpers.ApplicationInformation))]
    public class when_reading_application_information
    {
        It should_have_the_expected_application_name =
            () => Core.Helpers.ApplicationInformation.Name.ShouldContain("JDF Workflow Foundation");

        It should_have_a_version = () => Core.Helpers.ApplicationInformation.Version.ShouldNotBeNull();

        It should_have_a_file_version = () => Core.Helpers.ApplicationInformation.FileVersion.ShouldNotBeNull();
    }
}
