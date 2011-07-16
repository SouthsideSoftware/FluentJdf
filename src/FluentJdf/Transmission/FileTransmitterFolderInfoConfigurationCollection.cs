using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FluentJdf.Transmission {

    /// <summary>
    /// Collection of FileTransmitterFolderInfoConfigurationItem objects
    /// 1 for JDF, 1 for JMF and 1 for Attachments
    /// </summary>
    /// <remarks>
    /// Always ordered by the Order property.
    /// </remarks>
    /// 
    [Serializable]
    public class FileTransmitterFolderInfoConfigurationCollection : IEnumerable<FileTransmitterFolderInfoConfigurationItem> {
        private List<FileTransmitterFolderInfoConfigurationItem> _folderInfos = new List<FileTransmitterFolderInfoConfigurationItem>();

        /// <summary>
        /// Construct a default collection.
        /// </summary>
        public FileTransmitterFolderInfoConfigurationCollection() :
            this(null, null, null) {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="attachmentFolderInfo">The folder info for attachments.  If null, a default will be created.</param>
        /// <param name="jdfFolderInfo">The folder info for JDF.  If null, a default will be created.</param>
        /// <param name="jmfFolderInfo">The folder info for JMF.</param>
        public FileTransmitterFolderInfoConfigurationCollection(FileTransmitterFolderInfoConfigurationItem attachmentFolderInfo,
            FileTransmitterFolderInfoConfigurationItem jdfFolderInfo,
            FileTransmitterFolderInfoConfigurationItem jmfFolderInfo) {
            if (attachmentFolderInfo == null) {
                attachmentFolderInfo = new FileTransmitterFolderInfoConfigurationItem(FolderInfoTypeEnum.Attachment);
            }
            _folderInfos.Add(attachmentFolderInfo);

            if (jdfFolderInfo == null) {
                jdfFolderInfo = new FileTransmitterFolderInfoConfigurationItem(FolderInfoTypeEnum.Jdf);
            }
            _folderInfos.Add(jdfFolderInfo);

            if (jmfFolderInfo != null) {
                _folderInfos.Add(jmfFolderInfo);
            }

            _folderInfos.Sort();
        }

        /// <summary>
        /// Add a fileinfo to the collection.
        /// </summary>
        /// <param name="item">The item to add.  If an item of the type already exists, it is removed.</param>
        public void Add(FileTransmitterFolderInfoConfigurationItem item) {
            switch (item.FolderInfoType) {
                case FolderInfoTypeEnum.Attachment:
                    AttachmentFolderInfo = item;
                    break;
                case FolderInfoTypeEnum.Jdf:
                    JdfFolderInfo = item;
                    break;
                case FolderInfoTypeEnum.Jmf:
                    JmfFolderInfo = item;
                    break;
            }
        }

        /// <summary>
        /// Gets the count of the folder infos
        /// </summary>
        public int Count {
            get {
                return _folderInfos.Count;
            }
        }

        /// <summary>
        /// Gets or sets the folder info for attachments.
        /// </summary>
        public FileTransmitterFolderInfoConfigurationItem AttachmentFolderInfo {
            get {
                FileTransmitterFolderInfoConfigurationItem item = GetInfo(FolderInfoTypeEnum.Attachment);
                if (item != null && !item.Suppress) {
                    return item;
                }
                else {
                    return null;
                }
            }
            set {
                SetInfo(value, FolderInfoTypeEnum.Attachment);
            }
        }

        /// <summary>
        /// Gets the folder info at the given index.
        /// </summary>
        public FileTransmitterFolderInfoConfigurationItem this[int index] {
            get {
                return _folderInfos[index];
            }
        }

        private void SetInfo(FileTransmitterFolderInfoConfigurationItem val, FolderInfoTypeEnum type) {
            int matchIndex = -1;
            for (int index = 0; index < _folderInfos.Count; index++) {
                if (this[index].FolderInfoType == type) {
                    matchIndex = index;
                    break;
                }
            }

            if (matchIndex > -1) {
                _folderInfos.RemoveAt(matchIndex);
            }
            _folderInfos.Add(val);
            _folderInfos.Sort();
        }

        private FileTransmitterFolderInfoConfigurationItem GetInfo(FolderInfoTypeEnum type) {
            int matchIndex = -1;
            for (int index = 0; index < _folderInfos.Count; index++) {
                if (this[index].FolderInfoType == type) {
                    matchIndex = index;
                    break;
                }
            }

            if (matchIndex > -1) {
                return (FileTransmitterFolderInfoConfigurationItem)_folderInfos[matchIndex];
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Gets the folder info for JDF.
        /// </summary>
        public FileTransmitterFolderInfoConfigurationItem JdfFolderInfo {
            get {
                FileTransmitterFolderInfoConfigurationItem item = GetInfo(FolderInfoTypeEnum.Jdf);
                if (item != null && !item.Suppress) {
                    return item;
                }
                else {
                    return null;
                }
            }
            set {
                SetInfo(value, FolderInfoTypeEnum.Jdf);
            }
        }

        /// <summary>
        /// Gets the folder info for Jmf.
        /// </summary>
        public FileTransmitterFolderInfoConfigurationItem JmfFolderInfo {
            get {
                FileTransmitterFolderInfoConfigurationItem item = GetInfo(FolderInfoTypeEnum.Jmf);
                if (item != null && !item.Suppress) {
                    return item;
                }
                else {
                    return null;
                }
            }
            set {
                SetInfo(value, FolderInfoTypeEnum.Jmf);
            }
        }

        /// <summary>
        /// Dump diagnostic information to the trace listeners.
        /// </summary>
        public void Dump() {
            Trace.WriteLine("******************* FileTransmitterFolderInfoConfigurationCollection ********************");
            Trace.Indent();
            try {
                foreach (FileTransmitterFolderInfoConfigurationItem item in this) {
                    item.Dump();
                }
            }
            finally {
                Trace.Unindent();
            }
        }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<FileTransmitterFolderInfoConfigurationItem> GetEnumerator() {
            return _folderInfos.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _folderInfos.GetEnumerator();
        }
    }
}
