using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Testing;
using Machine.Specifications;
using System.IO;

namespace Infrastructure.Core.Tests.Unit.Helpers.DirectoryAndFileHelper {

    [Subject(typeof(Core.Helpers.DirectoryAndFileHelper))]
    public class when_save_file_to_stream {

        static MemoryStream stream = null;
        static FileInfo path = null;

        Establish context = () => {
            stream = new MemoryStream();
            for (int i = 0; i < 1000; i++) {
                for (byte j = 0; j < 255; j++) {
                    stream.WriteByte(j);
                }
            }
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            path = new FileInfo(Path.GetTempFileName());
        };

        Because because = () => Infrastructure.Core.Helpers.DirectoryAndFileHelper.SaveStreamToFile(stream, path, true);

        It should_exist_at_temporary_path = () => path.Exists.ShouldBeTrue();

        It should_match_stream_length = () => {
            File.Exists(path.FullName).ShouldBeTrue();
            using (var ms = new MemoryStream(File.ReadAllBytes(path.FullName))) {
                ms.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);
                ms.SameBytes(stream);
            }
        };

        Cleanup clean = () => {

            try {
                if (File.Exists(path.FullName)) {
                    File.Delete(path.FullName);
                }
            }
            finally {

            }

        };
    }
}
