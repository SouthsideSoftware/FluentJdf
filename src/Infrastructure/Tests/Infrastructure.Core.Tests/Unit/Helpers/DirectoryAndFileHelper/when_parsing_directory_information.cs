using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using System.IO;

namespace Infrastructure.Core.Tests.Unit.Helpers.DirectoryAndFileHelper {

    [Subject(typeof(Core.Helpers.DirectoryAndFileHelper))]
    public class when_parsing_directory_information {

        It should_not_fail_on_get_temp_path = () =>
            Infrastructure.Core.Helpers.DirectoryAndFileHelper.EnsureFolderExists(new System.IO.DirectoryInfo(Path.GetTempPath()));

        It should_fail_on_system_volume_information_subfolder = () => {

            Exception exception = null;

            try {
                Infrastructure.Core.Helpers.DirectoryAndFileHelper.EnsureFolderExists(new System.IO.DirectoryInfo(@"c:\System Volume Information\blah"));
            }
            catch (Exception ex) {
                exception = ex;
            }

            exception.ShouldNotBeNull();

        };

        It should_be_unauthorized_access_exception_on_system_volume_information_subfolder = () => {

            Exception exception = null;

            try {
                Infrastructure.Core.Helpers.DirectoryAndFileHelper.EnsureFolderExists(new System.IO.DirectoryInfo(@"c:\System Volume Information\blah"));
            }
            catch (Exception ex) {
                exception = ex;
            }

            exception.ShouldBeOfType<UnauthorizedAccessException>();

        };

    }
}
