using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Infrastructure.Core.Tests.Unit.TempFileStream
{
    [Subject(typeof(Core.TempFileStream))]
    public class when_using_temp_file_stream {
        static string fileName;
        static Core.TempFileStream tempStream;

        Establish context = () => {
                                tempStream = new Core.TempFileStream();
                                fileName = tempStream.Name;
                                var s = "test";
                                tempStream.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);
                                File.Exists(fileName).ShouldBeTrue();
                            };

        Because of = () => tempStream.Close();

        It should_have_deleted_file_after_close = () => File.Exists(fileName).ShouldBeFalse();
    }
}
