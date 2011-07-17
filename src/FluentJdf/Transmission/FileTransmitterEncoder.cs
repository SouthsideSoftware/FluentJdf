using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentJdf.Encoding;
using System.IO;
using Infrastructure.Core.CodeContracts;
using FluentJdf.LinqToJdf;

namespace FluentJdf.Transmission {

    /// <summary>
    /// A basic file transmitter encoder that may be used 
    /// as the base classs for other encoders.
    /// </summary>
    public class FileTransmitterEncoder {
        private List<FileTransmitterFolderInfoConfigurationItem> _folderInfo;
        //private ITransmissionPartFactory _transmissionFactory;

        private string _id;
        private string _urlBase;
        private bool _useMime = false;
        private IDictionary<string, string> _nameValues;

        /// <summary>
        /// The folder Info items (Attachment, jdf, jmf)
        /// </summary>
        public List<FileTransmitterFolderInfoConfigurationItem> FolderInfo {
            get {
                return _folderInfo;
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
        /// Additional Name Values
        /// </summary>
        public IDictionary<string, string> NameValues {
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
            _nameValues = nameValues ?? new Dictionary<string, string>();

            _folderInfo = new List<FileTransmitterFolderInfoConfigurationItem>();

            if (!_urlBase.EndsWith("\\")) {
                _urlBase = _urlBase + "\\";
            }
        }

        /// <summary>
        /// Add a new <see cref="FileTransmitterFolderInfoConfigurationItem"/>
        /// </summary>
        /// <param name="configItem"></param>
        public void AddFolderInfo(FileTransmitterFolderInfoConfigurationItem configItem) {
            if (FolderInfo.Any(item => item.FolderInfoType == configItem.FolderInfoType)) {
                throw new JdfException(string.Format("FolderInfoTypeEnum already exists.{0}", configItem.FolderInfoType));
            }

            FolderInfo.Add(configItem);
        }

        ///// <summary>
        ///// ctor
        ///// </summary>
        //public FileTransmitterEncoder(ITransmissionPartFactory transmissionFactory) {
        //    ParameterCheck.ParameterRequired(transmissionFactory, "transmissionFactory");
        //    _transmissionFactory = transmissionFactory;
        //}

        ///// <summary>
        ///// Prepare a collection of files for transmission.
        ///// </summary>
        ///// <param name="parts">The transmission parts.</param>
        ///// <returns>A collection of file transmission items in order of sending.</returns>
        ///// <remarks>
        ///// <para>
        ///// Path variables supported :
        ///// </para>
        ///// <para>
        ///// ${Root} = urlBase attribute of the FileTransmitterEncoder configuration.
        ///// </para>
        ///// <para>
        ///// ${Guid} = A GUID directory.
        ///// </para>
        ///// <para>
        ///// ${JobId} = A JobId directory.  JobId used is from the first JDF found in the parts.
        ///// </para>
        ///// <para>
        ///// ${JobKey} = A JobKey directory.  JobKey used is from the first JDF found in the parts (tree.Key).
        ///// </para>
        ///// </remarks>
        //public virtual FileTransmissionItemCollection PrepareTransmission(TransmissionPartCollection parts) {
        //    FileTransmissionItemCollection items = new FileTransmissionItemCollection();
        //    try {
        //        throw new NotImplementedException();

        //        //if (_configItem.UseMime) {
        //        //    MimeEncoding encoding = new MimeEncoding(_transmissionFactory);
        //        //    string contentType;
        //        //    OptimalEncodingResult encodingResult = encoding.OptimalEncode(parts, out contentType);
        //        //    try {
        //        //        items.Add(new FileTransmissionItem(encodingResult.Stream, new Uri(Path.Combine(_configItem.UrlBase, Guid.NewGuid().ToString() + ".mim")), 0));
        //        //    }
        //        //    finally {
        //        //        encodingResult.Dispose();
        //        //    }
        //        //}
        //        //else {
        //        //    if (_configItem.FolderInfoConfigurationCollection.JmfFolderInfo == null &&
        //        //        _configItem.FolderInfoConfigurationCollection.JdfFolderInfo == null &&
        //        //        _configItem.FolderInfoConfigurationCollection.AttachmentFolderInfo == null) {
        //        //        throw new JdfException(
        //        //            string.Format("The configuration of the file transmission encoder id {0} is invaild because it is configured not to send anything",
        //        //            _configItem.Id));
        //        //    }
        //        //    if (_configItem.FolderInfoConfigurationCollection.JmfFolderInfo != null &&
        //        //        (_configItem.FolderInfoConfigurationCollection.JdfFolderInfo == null ||
        //        //        _configItem.FolderInfoConfigurationCollection.AttachmentFolderInfo == null)) {
        //        //        throw new JdfException(
        //        //            string.Format("The configuration of the file transmission encoder id {0} is invaild because it is configured to send JMF but not JDF and the attachment",
        //        //            _configItem.Id));
        //        //    }
        //        //    if (_configItem.FolderInfoConfigurationCollection.JdfFolderInfo != null &&
        //        //        _configItem.FolderInfoConfigurationCollection.AttachmentFolderInfo == null) {
        //        //        throw new JdfException(
        //        //            string.Format("The configuration of the file transmission encoder id {0} is invaild because it is configured to send JDF but not the attachment",
        //        //            _configItem.Id));
        //        //    }
        //        //    Guid transmissionGuid = Guid.NewGuid();
        //        //    string jobId = "JDF_JobIdUnknown";
        //        //    string jobKey = "JDF_JobKeyUnknown";

        //        //    //pass over parts to get the job id and key
        //        //    foreach (TransmissionPart part in parts) {
        //        //        if (part is JdfTransmissionPart) {
        //        //            if (part.Tree.RootJdf.JobId.Length > 0) {
        //        //                jobId = "JDF_" + part.Tree.RootJdf.JobId;
        //        //            }
        //        //            if (part.Tree.Key.Length > 0) {
        //        //                jobKey = "JDF_" + part.Tree.Key;
        //        //            }
        //        //            break;
        //        //        }
        //        //    }

        //        //    //pass over parts to generate destination file names and mapping
        //        //    var urlMapping = new Dictionary<string, Uri>(StringComparer.OrdinalIgnoreCase);
        //        //    foreach (TransmissionPart part in parts) {
        //        //        FileTransmitterFolderInfoConfigurationItem folderConfigurationItem;
        //        //        string extension = null;
        //        //        if (part is JdfTransmissionPart) {
        //        //            folderConfigurationItem = _configItem.FolderInfoConfigurationCollection.JdfFolderInfo;
        //        //            extension = ".jdf";
        //        //        }
        //        //        else if (part is JmfTransmissionPart) {
        //        //            folderConfigurationItem = _configItem.FolderInfoConfigurationCollection.JmfFolderInfo;
        //        //            extension = ".jmf";
        //        //        }
        //        //        else {
        //        //            folderConfigurationItem = _configItem.FolderInfoConfigurationCollection.AttachmentFolderInfo;
        //        //            extension = FileTransmissionConfig.ExtensionOfMimeType(part.MimeType);
        //        //        }

        //        //        string fileName = part.FileName;
        //        //        if (fileName == null) {
        //        //            fileName = Guid.NewGuid().ToString() + extension;
        //        //        }
        //        //        else {
        //        //            fileName = Path.GetFileName(fileName);
        //        //        }

        //        //        if (folderConfigurationItem != null) {
        //        //            part.FileName = Path.Combine(ExpandFolder(folderConfigurationItem.DestinationFolder, _configItem.UrlBase, transmissionGuid, jobId, jobKey), fileName);
        //        //            string referencePath = Path.Combine(ExpandFolder(folderConfigurationItem.ReferenceFolder, _configItem.UrlBase, transmissionGuid, jobId, jobKey), fileName);
        //        //            urlMapping.Add("cid:" + part.Id.ToLower(), new Uri(referencePath));
        //        //        }
        //        //    }

        //        //    //fixup urls and add to the collection of files to send
        //        //    foreach (TransmissionPart part in parts) {
        //        //        FileTransmitterFolderInfoConfigurationItem folderConfigurationItem;
        //        //        if (part is JdfTransmissionPart) {
        //        //            folderConfigurationItem = _configItem.FolderInfoConfigurationCollection.JdfFolderInfo;
        //        //        }
        //        //        else if (part is JmfTransmissionPart) {
        //        //            folderConfigurationItem = _configItem.FolderInfoConfigurationCollection.JmfFolderInfo;
        //        //        }
        //        //        else {
        //        //            folderConfigurationItem = _configItem.FolderInfoConfigurationCollection.AttachmentFolderInfo;
        //        //        }

        //        //        if (part is JdfTransmissionPart) {
        //        //            FileSpecUrlMangler.MapFileSpecUrls(part.Tree, urlMapping, true);
        //        //            FileSpecUrlMangler.MapPreviewUrls(part.Tree, urlMapping, true);
        //        //        }
        //        //        else if (part is JmfTransmissionPart) {
        //        //            MapMessageUrls(part.Tree, urlMapping);
        //        //        }

        //        //        if (folderConfigurationItem != null) {
        //        //            TransmissionPartCollection singlePartCollection = new TransmissionPartCollection();
        //        //            singlePartCollection.Add(part);

        //        //            SimpleEncoding encoding = new SimpleEncoding();
        //        //            string contentType;
        //        //            OptimalEncodingResult encodingResult = encoding.OptimalEncode(singlePartCollection, out contentType);
        //        //            try {
        //        //                items.Add(new FileTransmissionItem(encodingResult.Stream, new Uri(part.FileName), folderConfigurationItem.Order));
        //        //            }
        //        //            finally {
        //        //                encodingResult.Dispose();
        //        //            }
        //        //        }
        //        //    }
        //        //}
        //    }
        //    catch (Exception err) {
        //        throw new JdfException(string.Format("Error occured while trying to encode transmission.  Message is {0}",
        //            err.Message), err);
        //    }
        //    //return items;
        //}

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

        ///// <summary>
        ///// Gets the encoder associated with a URI in a given transmitter configuration.
        ///// </summary>
        ///// <param name="config">The configuration associated with the transmitter.</param>
        ///// <param name="uri">The destination URI.</param>
        ///// <returns>The FileTransmitterEncoder for the URI or null if there is no FileTransmitterEncoder for the URI</returns>
        //public static FileTransmitterEncoder GetFileTransmitterEncoder(TransmissionConfigurationItem config, Uri uri) {
        //    FileTransmitterEncoderConfigurationItem item = FileTransmissionConfig.FileTransmitterEncoderConfiguration[uri];
        //    if (item != null) {
        //        return FileTransmitterEncoderFactory.Create(item);
        //    }
        //    else {
        //        return null;
        //    }
        //}

    }
}
