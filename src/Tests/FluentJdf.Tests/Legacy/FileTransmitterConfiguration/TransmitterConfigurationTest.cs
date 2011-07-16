//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using System.IO;
//using FluentJdf.Encoding;

//namespace FluentJdf.Tests.Legacy.FileTransmitterConfiguration {
    
//    [TestFixture()]
//    public class TransmitterConfigurationTest {
//        [Test]
//        public void Basic() {
//            TransmissionConfigurationCollection coll = Config.TransmissionConfiguration;
//            Assert.IsNotNull(coll, "There is a transmission configuration section");
//            TransmissionConfigurationItem fileConfig = coll["file"];
//            Assert.IsNotNull(fileConfig, "There is a file transmission configuration");
//            Assert.AreEqual(fileConfig.FileTransmitterEncoderConfiguration.Count, 6, "There are six encoders for the file transmitter");
//            Assert.IsNotNull(fileConfig.FileTransmitterEncoderConfiguration["ftOne"], "There is a encoder with id ftOne");
//            Assert.IsNotNull(fileConfig.FileTransmitterEncoderConfiguration["ftTwo"], "There is a encoder with id ftTwo");
//            Assert.IsNotNull(fileConfig.FileTransmitterEncoderConfiguration["ftThree"], "There is a encoder with id ftThree");

//            CheckBasicAttributes(fileConfig, "ftOne", true, true, true);
//            CheckBasicAttributes(fileConfig, "ftTwo", true, true, false);
//            CheckBasicAttributes(fileConfig, "ftThree", true, true, false);
//            CheckSpecificAttributes(fileConfig, "ftOne", @"${Root}\${Guid}", @"${Root}\${Guid}", 2, @"${Root}\${Guid}", @"${Root}\${Guid}", 1, "${Root}", "${Root}", 3);
//            CheckSpecificAttributes(fileConfig, "ftTwo", "${Root}", "${Root}", 0, "${Root}", "${Root}", 1, null, null, 2);
//            CheckSpecificAttributes(fileConfig, "ftThree", @"${Root}\${Guid}", @"d:\temp\specialFolders\${Guid}", 0,
//                @"${Root}\${JobId}", @"d:\temp\specialFolders\${JobId}", 1, null, null, 2);
//        }

//        [Test]
//        public void Factory() {
//            IFileTransmitterEncoder iFileTransmitterEncoder = IFileTransmitterEncoderFactory.Create(Config.TransmissionConfiguration["file"].FileTransmitterEncoderConfiguration["ftOne"]);
//            Assert.IsNotNull(iFileTransmitterEncoder);
//            Assert.IsTrue(iFileTransmitterEncoder is FileTransmitterEncoder, "The interface is of the correct class");
//        }

//        [Test]
//        public void SimpleSend() {
//            if (Directory.Exists(@"c:\temp\SimpleSend")) {
//                Directory.Delete(@"c:\temp\SimpleSend", true);
//            }
//            TransmissionPartCollection parts = new TransmissionPartCollection();
//            JdfTree jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\backwardsCompatible\file1.mim"));
//            Assert.IsTrue(File.Exists(@"c:\temp\SimpleSend\backwardsCompatible\file1.mim"), "File exists after backwards-compatible send");

//            parts = new TransmissionPartCollection();
//            jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\MimeEncoded\foo.mim"));

//            Assert.IsTrue(!Directory.Exists(@"c:\temp\SimpleSend\EncodedOne"), "The EncodedOne directory does not exist before send");
//            parts = new TransmissionPartCollection();
//            jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\EncodedOne\foo.mim"));
//            Assert.IsTrue(Directory.GetDirectories(@"c:\temp\SimpleSend\EncodedOne").Length == 1, "There is exactly one directory after the send");
//            Assert.IsTrue(Directory.GetFiles((Directory.GetDirectories(@"c:\temp\SimpleSend\EncodedOne")[0]), "*.*").Length == 2, "There are two files in the subdirectory after send");
//            Assert.IsTrue(Directory.GetFiles(@"c:\temp\SimpleSend\EncodedOne", "*.*").Length == 1, "There is one file in the main directory after send");

//            parts = new TransmissionPartCollection();
//            jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\EncodedThree\foo.mim"));
//        }

//        [Test]
//        public void SimpleSendProgrammaticSetup() {
//            if (Directory.Exists(@"c:\temp\SimpleSend")) {
//                Directory.Delete(@"c:\temp\SimpleSend", true);
//            }
//            TransmissionPartCollection parts = new TransmissionPartCollection();
//            JdfTree jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\backwardsCompatible\file1.mim"));
//            Assert.IsTrue(File.Exists(@"c:\temp\SimpleSend\backwardsCompatible\file1.mim"), "File exists after backwards-compatible send");

//            FileTransmitterFolderInfoConfigurationCollection folders = new FileTransmitterFolderInfoConfigurationCollection();
//            folders.Add(new FileTransmitterFolderInfoConfigurationItem("Attachment", @"${Root}\${Guid}", @"${Root}\${Guid}", 2, null));
//            folders.Add(new FileTransmitterFolderInfoConfigurationItem("Jdf", @"${Root}\${Guid}", @"${Root}\${Guid}", 1, null));
//            folders.Add(new FileTransmitterFolderInfoConfigurationItem("Jmf", "${Root}", "${Root}", 3, null));
//            FileTransmitterEncoderConfigurationItem configItem = new FileTransmitterEncoderConfigurationItem("test", "jdp.messaging.server.FileTransmitterEncoder, jdp.messaging",
//                new Uri(@"c:\temp\SimpleSend\EncodedProg\").ToString(), false, folders, null);

//            Assert.IsTrue(!Directory.Exists(@"c:\temp\SimpleSend\EncodedProg"), "The EncodedProg directory does not exist before send");
//            parts = new TransmissionPartCollection();
//            jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\xxxx\foo.mim"), IFileTransmitterEncoderFactory.Create(configItem));
//            Assert.IsTrue(Directory.GetDirectories(@"c:\temp\SimpleSend\EncodedProg").Length == 1, "There is exactly one directory after the send");
//            Assert.IsTrue(Directory.GetFiles((Directory.GetDirectories(@"c:\temp\SimpleSend\EncodedProg")[0]), "*.*").Length == 2, "There are two files in the subdirectory after send");
//            Assert.IsTrue(Directory.GetFiles(@"c:\temp\SimpleSend\EncodedProg", "*.*").Length == 1, "There is one file in the main directory after send");
//        }

//        private void CheckSpecificAttributes(TransmissionConfigurationItem fileConfig, string name,
//            string attachmentDest, string attachmentRef, int attachmentOrder,
//            string jdfDest, string jdfRef, int jdfOrder,
//            string jmfDest, string jmfRef, int jmfOrder) {
//            FileTransmitterFolderInfoConfigurationCollection folderInfos = fileConfig.FileTransmitterEncoderConfiguration[name].FolderInfoConfigurationCollection;
//            if (attachmentDest == null) {
//                Assert.IsNull(folderInfos.AttachmentFolderInfo);
//            }
//            else {
//                Assert.AreEqual(folderInfos.AttachmentFolderInfo.DestinationFolder, attachmentDest);
//                Assert.AreEqual(folderInfos.AttachmentFolderInfo.ReferenceFolder, attachmentRef);
//                Assert.AreEqual(folderInfos.AttachmentFolderInfo.Order, attachmentOrder);
//            }
//            if (jdfDest == null) {
//                Assert.IsNull(folderInfos.JdfFolderInfo);
//            }
//            else {
//                Assert.AreEqual(folderInfos.JdfFolderInfo.DestinationFolder, jdfDest);
//                Assert.AreEqual(folderInfos.JdfFolderInfo.ReferenceFolder, jdfRef);
//                Assert.AreEqual(folderInfos.JdfFolderInfo.Order, jdfOrder);
//            }
//            if (jmfDest == null) {
//                Assert.IsNull(folderInfos.JmfFolderInfo);
//            }
//            else {
//                Assert.AreEqual(folderInfos.JmfFolderInfo.DestinationFolder, jmfDest);
//                Assert.AreEqual(folderInfos.JmfFolderInfo.ReferenceFolder, jmfRef);
//                Assert.AreEqual(folderInfos.JmfFolderInfo.Order, jmfOrder);
//            }
//        }

//        private void CheckBasicAttributes(TransmissionConfigurationItem fileConfig, string name, bool attachmentExists, bool jdfExists, bool jmfExists) {
//            FileTransmitterFolderInfoConfigurationCollection folderInfos = fileConfig.FileTransmitterEncoderConfiguration[name].FolderInfoConfigurationCollection;
//            int expectedCount = 0;
//            if (attachmentExists) {
//                expectedCount++;
//            }
//            if (jdfExists) {
//                expectedCount++;
//            }
//            if (jmfExists) {
//                expectedCount++;
//            }
//            Assert.AreEqual(folderInfos.Count, expectedCount, string.Format("{0} has {1} folder infos", name, expectedCount));
//            if (attachmentExists) {
//                Assert.IsNotNull(folderInfos.AttachmentFolderInfo, string.Format("{0} has attachment folder folder info", name));
//                Assert.IsFalse(folderInfos.AttachmentFolderInfo.Order == -1);
//                Assert.IsNotNull(folderInfos.AttachmentFolderInfo.DestinationFolder);
//                Assert.IsNotNull(folderInfos.AttachmentFolderInfo.ReferenceFolder);
//            }
//            else {
//                Assert.IsNull(folderInfos.AttachmentFolderInfo);
//            }
//            if (jdfExists) {
//                Assert.IsNotNull(folderInfos.JdfFolderInfo, string.Format("{0} has JDF folder folder info", name));
//                Assert.IsFalse(folderInfos.JdfFolderInfo.Order == -1);
//                Assert.IsNotNull(folderInfos.JdfFolderInfo.DestinationFolder);
//                Assert.IsNotNull(folderInfos.JdfFolderInfo.ReferenceFolder);
//            }
//            else {
//                Assert.IsNull(folderInfos.JdfFolderInfo);
//            }
//            if (jmfExists) {
//                Assert.IsNotNull(folderInfos.JmfFolderInfo, string.Format("{0} has JMF folder folder info", name));
//                Assert.IsFalse(folderInfos.JmfFolderInfo.Order == -1);
//                Assert.IsNotNull(folderInfos.JmfFolderInfo.DestinationFolder);
//                Assert.IsNotNull(folderInfos.JmfFolderInfo.ReferenceFolder);
//            }
//            else {
//                Assert.IsNull(folderInfos.JmfFolderInfo);
//            }
//        }

//        [Test]
//        public void NoJdf() {
//            //test for explicit JDF suppression
//            if (Directory.Exists(@"c:\temp\SimpleSend")) {
//                Directory.Delete(@"c:\temp\SimpleSend", true);
//            }
//            TransmissionPartCollection parts = new TransmissionPartCollection();
//            JdfTree jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\ftFive\file1.mim"));
//            string[] files = Directory.GetFiles(@"c:\temp\SimpleSend\ftFive", "*.jdf");
//            Assert.IsTrue(files.Length == 0, "No JDF files are created when the JDF configuration has suppress=true");
//            Assert.IsTrue(File.Exists(Path.Combine(@"c:\temp\SimpleSend\ftFive", "signs.jpg")), "signs.jpg exists as expected");

//            //Test for default JDF behavior
//            if (Directory.Exists(@"c:\temp\SimpleSend")) {
//                Directory.Delete(@"c:\temp\SimpleSend", true);
//            }
//            parts = new TransmissionPartCollection();
//            jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\ftSix\file1.mim"));
//            files = Directory.GetFiles(@"c:\temp\SimpleSend\ftSix", "*.jdf");
//            Assert.IsTrue(files.Length == 1, "JDF file exists even though not explicity configured due to default behavior");
//            Assert.IsTrue(File.Exists(Path.Combine(@"c:\temp\SimpleSend\ftSix", "signs.jpg")), "signs.jpg exists as expected");

//            //test for explicit attachment suppression
//            if (Directory.Exists(@"c:\temp\SimpleSend")) {
//                Directory.Delete(@"c:\temp\SimpleSend", true);
//            }
//            parts = new TransmissionPartCollection();
//            jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\temp\SimpleSend\ftSeven\file1.mim"));
//            files = Directory.GetFiles(@"c:\temp\SimpleSend\ftSeven", "*.jdf");
//            Assert.IsTrue(files.Length == 0, "JDF file does not exist due to default behavior");
//            files = Directory.GetFiles(@"c:\temp\SimpleSend\ftSeven", "*.mim");
//            Assert.IsTrue(files.Length == 1, "Mime file exists due to default behavior");
//            Assert.IsTrue(!File.Exists(Path.Combine(@"c:\temp\SimpleSend\ftSix", "signs.jpg")), "signs.jpg does not exist because it was explicitly suppressed.");
//        }

//        [Test]
//        public void RootDirectory() {
//            //test for explicit JDF suppression
//            string[] files = Directory.GetFiles(@"c:\", "*.jdf");
//            foreach (string file in files) {
//                File.SetAttributes(file, FileAttributes.Normal);
//                File.Delete(file);
//            }
//            if (File.Exists(@"c:\signs.jpg")) {
//                File.SetAttributes(@"c:\signs.jpg", FileAttributes.Normal);
//                File.Delete(@"c:\signs.jpg");
//            }
//            TransmissionPartCollection parts = new TransmissionPartCollection();
//            JdfTree jmf = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "SimpleCommandSubmitQEntryMultiPart.xml"));
//            parts.Add(jmf, Retrieval.JdfsAndAllAssets);
//            Transmitter.Send(parts, new Uri(@"c:\file1.mim"));
//            files = Directory.GetFiles(@"c:\", "*.jdf");
//            Assert.IsTrue(files.Length == 1, "One JDF file is created in the root");
//            Assert.IsTrue(File.Exists(Path.Combine(@"c:\", "signs.jpg")), "signs.jpg exists as expected");
//        }
//    }
//}
