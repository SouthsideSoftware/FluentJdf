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
using System.Xml.Linq;
using FluentJdf.Utility;
using FluentJdf.Transmission.Logging;
using Infrastructure.Core.Logging;

namespace FluentJdf.Transmission {

    /// <summary>
    /// A basic file transmitter encoder that may be used 
    /// as the base classs for other encoders.
    /// </summary>
    public class FileTransmitterEncoder {

        static ILog logger = LogManager.GetLogger(typeof(FileTransmitterEncoder));

        private List<FileTransmitterFolderInfoConfigurationItem> folderInfo;

        private string id;
        private string localPath;
        private Uri urlBase;
        private bool useMime = false;
        private ReadOnlyDictionary<string, string> nameValues;

        /// <summary>
        /// The folder Info items (Attachment, jdf, jmf)
        /// </summary>
        public ReadOnlyCollection<FileTransmitterFolderInfoConfigurationItem> FolderInfo {
            get {
                return folderInfo.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the unique ID
        /// </summary>
        public string Id {
            get {
                return id;
            }
        }

        /// <summary>
        /// Local Path after normalizing.
        /// </summary>
        public string LocalPath {
            get {
                return localPath;
            }
        }

        /// <summary>
        /// Additional Name Values
        /// </summary>
        public ReadOnlyDictionary<string, string> NameValues {
            get {
                return nameValues;
            }
        }

        /// <summary>
        /// Gets the URI base of this item.
        /// </summary>
        public Uri UrlBase {
            get {
                return urlBase;
            }
        }

        /// <summary>
        /// Gets true if this encoder should use mime to package the parts
        /// </summary>
        public bool UseMime {
            get {
                return useMime;
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
            ParameterCheck.ParameterRequired(urlBase, "uriBase");
            var uri = new Uri(urlBase);
            Construct(id, uri, useMime, nameValues);
        }

        /// <summary>
        /// Create a new FileTransmitterEncoder
        /// </summary>
        /// <param name="id">The id of the encoder</param>
        /// <param name="urlBase">The url base</param>
        /// <param name="useMime">UseMime</param>
        /// <param name="nameValues">Additional Parameters</param>
        public FileTransmitterEncoder(string id, Uri urlBase, bool useMime = false, IDictionary<string, string> nameValues = null) {
            Construct(id, urlBase, useMime, nameValues);
        }

        private void Construct(string id, Uri urlBase, bool useMime = false, IDictionary<string, string> nameValues = null) {
            ParameterCheck.ParameterRequired(id, "id");
            ParameterCheck.ParameterRequired(urlBase, "uriBase");

            this.id = id;
            this.urlBase = urlBase.EnsureTrailingSlash();
            this.useMime = useMime;
            this.nameValues = new ReadOnlyDictionary<string, string>(nameValues ?? new Dictionary<string, string>());

            this.folderInfo = new List<FileTransmitterFolderInfoConfigurationItem>();

            this.localPath = urlBase.EnsureTrailingSlash().GetLocalPath();
        }

        /// <summary>
        /// Add a new <see cref="FileTransmitterFolderInfoConfigurationItem"/>
        /// </summary>
        /// <param name="configItem"></param>
        public void AddFolderInfo(FileTransmitterFolderInfoConfigurationItem configItem) {
            if (FolderInfo.Any(item => item.FolderInfoType == configItem.FolderInfoType)) {
                throw new JdfException(string.Format(FluentJdf.Resources.Messages.FolderInfoTypeEnum0AlreadyExists, configItem.FolderInfoType));
            }

            folderInfo.Add(configItem);
        }

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
        /// <param name="encodingfactory">The encodingfactory</param>
        /// <param name="transmissionLogger">The transmissionLogger</param>
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
        public virtual List<FileTransmissionItem> PrepareTransmission(ITransmissionPartCollection parts,
                                                                        ITransmissionPartFactory transmissionFactory,
                                                                        IEncodingFactory encodingfactory,
                                                                        ITransmissionLogger transmissionLogger) {
            var items = new List<FileTransmissionItem>();
            try {
                if (UseMime) {
                    MimeEncoding encoding = new MimeEncoding(transmissionFactory);
                    var encoded = encoding.Encode(parts);
                    using (var mimeResult = encoded.Stream) {
                        items.Add(new FileTransmissionItem(mimeResult, new Uri(Path.Combine(LocalPath, Guid.NewGuid().ToString() + ".mim")), encoded.ContentType, 0));
                    }
                }
                else {
                    if (JmfFolderInfo == null && JdfFolderInfo == null && AttachmentFolderInfo == null) {
                        throw new JdfException(
                            string.Format(FluentJdf.Resources.Messages.TheConfigurationOfTheFileTransmissionEncoderId0IsInvaild,
                            Id));
                    }
                    if (JmfFolderInfo != null && (JdfFolderInfo == null || AttachmentFolderInfo == null)) {
                        throw new JdfException(
                            string.Format(FluentJdf.Resources.Messages.TheConfigurationOfTheFileTransmissionEncoderId0IsInvaildJMFNoJDF,
                            Id));
                    }
                    if (JdfFolderInfo != null && AttachmentFolderInfo == null) {
                        throw new JdfException(
                            string.Format(FluentJdf.Resources.Messages.TheConfigurationOfTheFileTransmissionEncoderId0IsInvaildJDFNoAttach,
                            Id));
                    }

                    Guid transmissionGuid = Guid.NewGuid();
                    string jobId = "JDF_JobIdUnknown";
                    string jobKey = "JDF_JobKeyUnknown";

                    var jdfTransmissionPart = parts.TicketPart;

                    //pass over parts to get the job id and key
                    if (jdfTransmissionPart != null) {

                        //TODO is this the best way to obtain the ticket? We know it must exist since we are on the correct mime item.
                        var ticket = parts.Ticket;

                        if (ticket.Root.GetJobId().Length > 0) {
                            jobId = "JDF_" + ticket.Root.GetJobId();
                        }
                        if (ticket.Root.GetId().Length > 0) {
                            jobKey = "JDF_" + ticket.Root.GetId();
                        }
                    }

                    var itemsToProcess = new List<KeyValuePair<ITransmissionPart, string>>();

                    //pass over parts to generate destination file names and mapping
                    var urlMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    foreach (ITransmissionPart part in parts) {
                        FileTransmitterFolderInfoConfigurationItem folderConfigurationItem;
                        string extension = null;
                        if (part.MimeType == MimeTypeHelper.JdfMimeType) {
                            folderConfigurationItem = JdfFolderInfo;
                            extension = ".jdf";
                        }
                        if (part.MimeType == MimeTypeHelper.JmfMimeType) {
                            folderConfigurationItem = JmfFolderInfo;
                            extension = ".jmf";
                        }
                        else {
                            folderConfigurationItem = AttachmentFolderInfo;
                            extension = MimeTypeHelper.MimeTypeExtension(part.MimeType);
                        }

                        string fileName = Guid.NewGuid().ToString() + extension; //we do not have an original filename, we can only create one.

                        if (folderConfigurationItem != null) {
                            var newFileName = Path.Combine(ExpandFolder(folderConfigurationItem.DestinationFolder, transmissionGuid, jobId, jobKey), fileName);
                            string referencePath = Path.Combine(ExpandFolder(folderConfigurationItem.ReferenceFolder, transmissionGuid, jobId, jobKey), fileName);
                            urlMapping.Add("cid:" + part.Id.ToLower(), referencePath);
                            itemsToProcess.Add(new KeyValuePair<ITransmissionPart, string>(part, newFileName));
                        }
                    }

                    //fixup urls and add to the collection of files to send
                    foreach (var processPart in itemsToProcess) {
                        FileTransmitterFolderInfoConfigurationItem folderConfigurationItem;

                        var part = processPart.Key;
                        var file = processPart.Value;

                        if (part.MimeType == MimeTypeHelper.JdfMimeType) {
                            folderConfigurationItem = JdfFolderInfo;
                        }
                        if (part.MimeType == MimeTypeHelper.JmfMimeType) {
                            folderConfigurationItem = JmfFolderInfo;
                        }
                        else {
                            folderConfigurationItem = AttachmentFolderInfo;
                        }

                        //TODO is this the best way to obtain the ticket? We know it must exist since we are on the correct mime item.
                        if (part.MimeType == MimeTypeHelper.JdfMimeType) {
                            FileSpecUrlMangler.MapFileSpecUrls(parts.Ticket, urlMapping, true);
                            FileSpecUrlMangler.MapPreviewUrls(parts.Ticket, urlMapping, true);
                        }

                        //TODO is this the best way to obtain the message? We know it must exist since we are on the correct mime item.
                        if (part.MimeType == MimeTypeHelper.JmfMimeType) {
                            MapMessageUrls(parts.Message, urlMapping);
                        }

                        if (folderConfigurationItem != null) {
                            if (!folderConfigurationItem.Suppress) {
                                var encodingResult = encodingfactory.GetEncodingForMimeType(part.MimeType).Encode(part);
                                transmissionLogger.Log(new TransmissionData(encodingResult.Stream, encodingResult.ContentType, "Request"));

                                items.Add(new FileTransmissionItem(encodingResult.Stream, new Uri(file), part.MimeType, folderConfigurationItem.Order));
                            }
                        }
                    }
                }
            }
            catch (Exception err) {
                throw new JdfException(string.Format(FluentJdf.Resources.Messages.ErrorOccuredWhileTryingToEncodeTransmissionMessageIs,
                    err.Message), err);
            }
            return items;
        }

        internal void MapMessageUrls(Message message, IDictionary<string, string> urlMapping) {
            // Access the URL in the QueueSubmissionParams or ResubmissionParams of each Command element in the JMF.
            foreach (var command in message.Root.SelectJDFDescendants(Element.Command)) {
                bool toProcess = false;

                var commandType = command.GetAttributeValueOrNull("Type");

                IEnumerable<XElement> submissionParams = null;

                if (commandType == Command.SubmitQueueEntry) {
                    submissionParams = command.SelectJDFDescendants(Element.QueueSubmissionParams);
                    if (submissionParams.Count() == 0) {
                        throw new JdfException(FluentJdf.Resources.Messages.QueueSubmissionParamsAreRequiredInSubmitQueueEntry);
                    }
                    else {
                        toProcess = true;
                    }
                }
                if (commandType == Command.ResubmitQueueEntry) {
                    submissionParams = command.SelectJDFDescendants(Element.ResubmissionParams);
                    if (submissionParams.Count() == 0) {
                        throw new JdfException(FluentJdf.Resources.Messages.ReSubmissionParamsAreRequiredInResubmitQueueEntry);
                    }
                    else {
                        toProcess = true;
                    }
                }
                if (toProcess) {
                    string jdfUrl = submissionParams.First().GetAttributeValueOrNull("URL").ToString().ToLower();
                    string newUrl = urlMapping.FirstOrDefault(item => item.Key.Equals(jdfUrl, StringComparison.OrdinalIgnoreCase)).Value;
                    if (newUrl != null) {
                        submissionParams.First().AddOrReplaceAttribute(new XAttribute("URL", (new Uri(newUrl)).AbsoluteUri));
                    }
                }
            }
        }

        /// <summary>
        /// Expands special variables in folder names found in
        /// the configuration.
        /// </summary>
        /// <param name="folderToExpand">The folder name from configuration.</param>
        /// <param name="guid">A guid unique to the entire transmission.</param>
        /// <param name="jobId">Job id of the first JDF part</param>
        /// <param name="jobKey">Job key (JdfTree.Key) of the first JDF part.</param>
        /// <returns>Folder with variables expanded.</returns>
        internal string ExpandFolder(string folderToExpand, Guid guid, string jobId, string jobKey) {
            string newFolder = string.Copy(folderToExpand).ToLower();
            newFolder = FileTransmissionConfig.ReplaceVar(newFolder, "root", LocalPath);
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
                id, urlBase, useMime);
            return sb.ToString();
        }

    }
}
