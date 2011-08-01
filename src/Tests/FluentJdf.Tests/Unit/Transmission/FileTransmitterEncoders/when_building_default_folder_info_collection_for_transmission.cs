using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using FluentJdf.Configuration;
using FluentJdf.LinqToJdf;
using FluentJdf.Transmission;
using System.IO;

namespace FluentJdf.Tests.Unit.Transmission.FileTransmitterEncoders {

    [Subject(typeof(FluentJdf.Transmission.FileTransmitterEncoder))]
    public class when_building_default_folder_info_collection_for_transmission {

        static FileTransmitterEncoder encoder;

        Because because = () => encoder = FileTransmitterEncoder.BuildDefaultFolderInfoCollection(new FileTransmitterEncoder("id", @"file:///c:\temp"));

        It should_have_all_folder_info_items = () => encoder.FolderInfo.Count.ShouldEqual(3);

        It should_have_attachment_first = () => encoder.FolderInfo.First().FolderInfoType.ShouldEqual(FolderInfoTypeEnum.Attachment);

        It should_have_jdf_second = () => encoder.FolderInfo.Skip(1).First().FolderInfoType.ShouldEqual(FolderInfoTypeEnum.Jdf);

        It should_have_jmf_last = () => encoder.FolderInfo.Last().FolderInfoType.ShouldEqual(FolderInfoTypeEnum.Jmf);

        It should_have_attachment_same_path = () => encoder.FolderInfo.First().DestinationFolder.ShouldEqual(encoder.UrlBase.ToString());

        It should_have_jdf_same_path = () => encoder.FolderInfo.Skip(1).First().DestinationFolder.ShouldEqual(encoder.UrlBase.ToString());

        It should_have_jmf_same_path = () => encoder.FolderInfo.Last().DestinationFolder.ShouldEqual(encoder.UrlBase.ToString());

    }
}
