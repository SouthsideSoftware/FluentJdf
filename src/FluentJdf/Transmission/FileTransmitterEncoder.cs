using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using System.IO;
using Infrastructure.Core.CodeContracts;
using FluentJdf.LinqToJdf;
using System.Collections.ObjectModel;
using Infrastructure.Core;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Transmission {

    /// <summary>
    /// A basic file transmitter encoder that may be used 
    /// as the base classs for other encoders.
    /// </summary>
    public class FileTransmitterEncoder {
        private List<FileTransmitterFolderInfoConfigurationItem> _folderInfo;
        //private ITransmissionPartFactory _transmissionFactory;

        private string _id;
        private string _localPath;
        private string _urlBase;
        private bool _useMime = false;
        private ReadOnlyDictionary<string, string> _nameValues;

        /// <summary>
        /// The folder Info items (Attachment, jdf, jmf)
        /// </summary>
        public ReadOnlyCollection<FileTransmitterFolderInfoConfigurationItem> FolderInfo {
            get {
                return _folderInfo.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the unique ID
        /// </summary>
        public string Id {
            get {
                return _id;
            }
        }

        /// <summary>
        /// Local Path after normalizing.
        /// </summary>
        public string LocalPath {
            get {
                return _localPath;
            }
        }

        /// <summary>
        /// Additional Name Values
        /// </summary>
        public ReadOnlyDictionary<string, string> NameValues {
            get {
                return _nameValues;
            }
        }

        /// <summary>
        /// Gets the URI base of this item.
        /// </summary>
        public string UrlBase {
            get {
                return _urlBase;
            }
        }

        /// <summary>
        /// Gets true if this encoder should use mime to package the parts
        /// </summary>
        public bool UseMime {
            get {
                return _useMime;
            }
        }

        /// <summary>
        /// Create a new FileTransmitterEncoder
        /// </summary>
        /// <param name="id">The id of the encoder</param>
        /// <param name="urlBase">The url base</param>
        /// <param name="useMime">UseMime</param>
        /// <param name="nameValues">Additional Parameters</param>
        public FileTransmitterEncoder(string id, string urlBase, bool useMime = false, IDictionary<string, string> nameValues = null) {
            ParameterCheck.ParameterRequired(id, "id");
            ParameterCheck.ParameterRequired(urlBase, "uriBase");

            _id = id;
            _urlBase = urlBase;
            _useMime = useMime;
            _nameValues = new ReadOnlyDictionary<string, string>(nameValues ?? new Dictionary<string, string>());

            _folderInfo = new List<FileTransmitterFolderInfoConfigurationItem>();

            if (!_urlBase.EndsWith("\\")) {
                _urlBase = _urlBase + "\\";
            }

            Uri uri = new Uri(_urlBase);
            _localPath = Path.GetDirectoryName(uri.LocalPath);
        }

        /// <summary>
        /// Add a new <see cref="FileTransmitterFolderInfoConfigurationItem"/>
        /// </summary>
        /// <param name="configItem"></param>
        public void AddFolderInfo(FileTransmitterFolderInfoConfigurationItem configItem) {
            if (FolderInfo.Any(item => item.FolderInfoType == configItem.FolderInfoType)) {
                throw new JdfException(string.Format("FolderInfoTypeEnum '{0}' already exists.", configItem.FolderInfoType));
            }

            _folderInfo.Add(configItem);
        }

        ///// <summary>
        ///// ctor
        ///// </summary>
        //public FileTransmitterEncoder(ITransmissionPartFactory transmissionFactory) {
        //    ParameterCheck.ParameterRequired(transmissionFactory, "transmissionFactory");
        //    _transmissionFactory = transmissionFactory;
        //}

        /// <summary>
        /// Gets the folder info for Jmf.
        /// </summary>
        private FileTransmitterFolderInfoConfigurationItem JmfFolderInfo {
            get {
                return FolderInfo.FirstOrDefault(item => item.FolderInfoType == FolderInfoTypeEnum.Jmf
                                                && !item.Suppress);
            }
        }

        /// <summary>
        /// Gets the folder info for Jmf.
        /// </summary>
        private FileTransmitterFolderInfoConfigurationItem JdfFolderInfo {
            get {
                return FolderInfo.FirstOrDefault(item => item.FolderInfoType == FolderInfoTypeEnum.Jdf
                                                && !item.Suppress);
            }
        }

        /// <summary>
        /// Gets the folder info for Jmf.
        /// </summary>
        private FileTransmitterFolderInfoConfigurationItem AttachmentFolderInfo {
            get {
                return FolderInfo.FirstOrDefault(item => item.FolderInfoType == FolderInfoTypeEnum.Attachment
                                                && !item.Suppress);
            }
        }

        /// <summary>
        /// Prepare a collection of files for transmission.
        /// </summary>
        /// <param name="parts">The transmission parts.</param>
        /// <param name="transmissionFactory">Transmission factory that is needed but not used.</param>
        /// <returns>A collection of file transmission items in order of sending.</returns>
        /// <remarks>
        /// <para>
        /// Path variables supported :
        /// </para>
        /// <para>
        /// ${Root} = urlBase attribute of the FileTransmitterEncoder configuration.
        /// </para>
        /// <para>
        /// ${Guid} = A GUID directory.
        /// </para>
        /// <para>
        /// ${JobId} = A JobId directory.  JobId used is from the first JDF found in the parts.
        /// </para>
        /// <para>
        /// ${JobKey} = A JobKey directory.  JobKey used is from the first JDF found in the parts (tree.Key).
        /// </para>
        /// </remarks>
        public virtual ITransmissionPartCollection PrepareTransmission(ITransmissionPartCollection parts, ITransmissionPartFactory transmissionFactory) {
            ITransmissionPartCollection items = new TransmissionPartCollection();
            try {
                throw new NotImplementedException();

                //if (UseMime) {
                //    MimeEncoding encoding = new MimeEncoding(transmissionFactory);
                //    var encoded = encoding.Encode(parts);
                //    using (var mimeResult = encoded.Stream) {
                //        items.Add(new FileTransmissionItem(mimeResult, new Uri(Path.Combine(UrlBase, Guid.NewGuid().ToString() + ".mim")), encoded.ContentType, 0));
                //    }
                //    string contentType;
                //}
                //else {
                //    if (JmfFolderInfo == null && JdfFolderInfo == null && AttachmentFolderInfo == null) {
                //        throw new JdfException(
                //            string.Format("The configuration of the file transmission encoder id {0} is invaild because it is configured not to send anything",
                //            Id));
                //    }
                //    if (JmfFolderInfo != null && (JdfFolderInfo == null || AttachmentFolderInfo == null)) {
                //        throw new JdfException(
                //            string.Format("The configuration of the file transmission encoder id {0} is invaild because it is configured to send JMF but not JDF and the attachment",
                //            Id));
                //    }
                //    if (JdfFolderInfo != null && AttachmentFolderInfo == null) {
                //        throw new JdfException(
                //            string.Format("The configuration of the file transmission encoder id {0} is invaild because it is configured to send JDF but not the attachment",
                //            Id));
                //    }
                //    Guid transmissionGuid = Guid.NewGuid();
                //    string jobId = "JDF_JobIdUnknown";
                //    string jobKey = "JDF_JobKeyUnknown";

                //    var helperType = MimeTypeHelper.JdfMimeType;

                //    //pass over parts to get the job id and key
                //    foreach (ITransmissionPart part in parts) {
                //        if (part.MimeType == MimeTypeHelper.JdfMimeType) {//if (part is JdfTransmissionPart) {
                //            if (part.Tree.RootJdf.JobId.Length > 0) {
                //                jobId = "JDF_" + part.Tree.RootJdf.JobId;
                //            }
                //            if (part.Tree.Key.Length > 0) {
                //                jobKey = "JDF_" + part.Tree.Key;
                //            }
                //            break;
                //        }
                //    }

                //    //pass over parts to generate destination file names and mapping
                //    var urlMapping = new Dictionary<string, Uri>(StringComparer.OrdinalIgnoreCase);
                //    foreach (TransmissionPart part in parts) {
                //        FileTransmitterFolderInfoConfigurationItem folderConfigurationItem;
                //        string extension = null;
                //        if (part.MimeType == MimeTypeHelper.JdfMimeType) {
                //            folderConfigurationItem = JdfFolderInfo;
                //            extension = ".jdf";
                //        }
                //        if (part.MimeType == MimeTypeHelper.JmfMimeType) {
                //            folderConfigurationItem = JmfFolderInfo;
                //            extension = ".jmf";
                //        }
                //        else {
                //            folderConfigurationItem = AttachmentFolderInfo;
                //            extension = MimeTypeHelper.MimeTypeExtension(part.MimeType);
                //        }

                //        string fileName = part.FileName;
                //        if (fileName == null) {
                //            fileName = Guid.NewGuid().ToString() + extension;
                //        }
                //        else {
                //            fileName = Path.GetFileName(fileName);
                //        }

                //        if (folderConfigurationItem != null) {
                //            part.FileName = Path.Combine(ExpandFolder(folderConfigurationItem.DestinationFolder, UrlBase, transmissionGuid, jobId, jobKey), fileName);
                //            string referencePath = Path.Combine(ExpandFolder(folderConfigurationItem.ReferenceFolder, UrlBase, transmissionGuid, jobId, jobKey), fileName);
                //            urlMapping.Add("cid:" + part.Id.ToLower(), new Uri(referencePath));
                //        }
                //    }

                //    //fixup urls and add to the collection of files to send
                //    foreach (TransmissionPart part in parts) {
                //        FileTransmitterFolderInfoConfigurationItem folderConfigurationItem;

                //        if (part.MimeType == MimeTypeHelper.JdfMimeType) {
                //            folderConfigurationItem = JdfFolderInfo;
                //        }
                //        if (part.MimeType == MimeTypeHelper.JmfMimeType) {
                //            folderConfigurationItem = JmfFolderInfo;
                //        }
                //        else {
                //            folderConfigurationItem = AttachmentFolderInfo;
                //        }



                //        if (part is JdfTransmissionPart) {
                //            FileSpecUrlMangler.MapFileSpecUrls(part.Tree, urlMapping, true);
                //            FileSpecUrlMangler.MapPreviewUrls(part.Tree, urlMapping, true);
                //        }
                //        else if (part is JmfTransmissionPart) {
                //            MapMessageUrls(part.Tree, urlMapping);
                //        }

                //        if (folderConfigurationItem != null) {
                //            TransmissionPartCollection singlePartCollection = new TransmissionPartCollection();
                //            singlePartCollection.Add(part);

                //            SimpleEncoding encoding = new SimpleEncoding();
                //            string contentType;
                //            OptimalEncodingResult encodingResult = encoding.OptimalEncode(singlePartCollection, out contentType);
                //            try {
                //                items.Add(new FileTransmissionItem(encodingResult.Stream, new Uri(part.FileName), folderConfigurationItem.Order));
                //            }
                //            finally {
                //                encodingResult.Dispose();
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception err) {
                throw new JdfException(string.Format("Error occured while trying to encode transmission.  Message is {0}",
                    err.Message), err);
            }
            //return items;
        }

        //private void MapMessageUrls(JdfTree jmfTree, Dictionary<string, Uri> urlMapping) {
        //    // Access the URL in the QueueSubmissionParams or ResubmissionParams of each Command element in the JMF.
        //    foreach (JmfCommand command in jmfTree.Root.GetElementsByName("Command")) {
        //        bool toProcess = false;
        //        ElementList submissionParams = null;
        //        if (command.Attributes["Type"].ToString() == "SubmitQueueEntry") {
        //            submissionParams = command.GetElementsByName("QueueSubmissionParams");
        //            if (submissionParams.Count == 0) {
        //                OAIException.Throw(new OAIException("QueueSubmissionParams are required in SubmitQueueEntry"));
        //            }
        //            else {
        //                toProcess = true;
        //            }
        //        }
        //        if (command.Attributes["Type"].ToString() == "ResubmitQueueEntry") {
        //            submissionParams = command.GetElementsByName("ResubmissionParams");
        //            if (submissionParams.Count == 0) {
        //                OAIException.Throw(new OAIException("ReSubmissionParams are required in ResubmitQueueEntry"));
        //            }
        //            else {
        //                toProcess = true;
        //            }
        //        }
        //        if (toProcess) {
        //            //HACK: ToLower();
        //            string jdfUrl = submissionParams[0].Attributes["URL"].ToString().ToLower();

        //            if (urlMapping.Contains(jdfUrl)) {
        //                submissionParams[0].Attributes["URL"].SetValue(((Uri)urlMapping[jdfUrl]).AbsoluteUri);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Expands special variables in folder names found in
        /// the configuration.
        /// </summary>
        /// <param name="folderToExpand">The folder name from configuration.</param>
        /// <param name="baseFolder">urlBase from the configuration.</param>
        /// <param name="guid">A guid unique to the entire transmission.</param>
        /// <param name="jobId">Job id of the first JDF part</param>
        /// <param name="jobKey">Job key (JdfTree.Key) of the first JDF part.</param>
        /// <returns>Folder with variables expanded.</returns>
        protected string ExpandFolder(string folderToExpand, string baseFolder, Guid guid, string jobId, string jobKey) {
            string localBaseFolder = new Uri(baseFolder).LocalPath;
            string newFolder = string.Copy(folderToExpand).ToLower();
            newFolder = FileTransmissionConfig.ReplaceVar(newFolder, "root", localBaseFolder);
            newFolder = FileTransmissionConfig.ReplaceVar(newFolder, "guid", guid.ToString());
            newFolder = FileTransmissionConfig.ReplaceVar(newFolder, "jobid", jobId);
            newFolder = FileTransmissionConfig.ReplaceVar(newFolder, "jobkey", jobKey);

            return newFolder;
        }

        /// <summary>
        /// Get a string representation of this object.
        /// </summary>
        /// <returns>A string with information about the object.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id: {0} Url Base: {1} Use Mime: {2}",
                _id, _urlBase, _useMime);
            return sb.ToString();
        }

    }
}
