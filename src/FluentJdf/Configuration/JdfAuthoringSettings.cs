using FluentJdf.LinqToJdf;
using Infrastructure.Core.Helpers;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings related to authoring JDF
    /// </summary>
    public class JdfAuthoringSettings {
        string agentName;
        string agentVersion;
        string author;
        bool createAuditOnNewRootJdf;
        bool generateJobId;
        bool generateJobPartId;
        string jdfVersion;
        string senderId;


        /// <summary>
        /// Gets the setting for option of generating job id.
        /// </summary>
        /// <remarks>When true (the default), a unique job id
        /// is generated and placed in the root node.</remarks>
        public bool GenerateJobId {
            get { return generateJobId; }
            internal set { generateJobId = value; }
        }

        /// <summary>
        /// Gets the setting for option of generating job part id.
        /// </summary>
        /// <remarks>When true (the default), a unique job part id
        /// is generated and placed in new jdf nodes that are not the root.</remarks>
        public bool GenerateJobPartId {
            get { return generateJobPartId; }
            internal set { generateJobPartId = value; }
        }

        /// <summary>
        /// Gets the agent name for this configuration.
        /// </summary>
        /// <remarks>Defaults to value in the AssemblyProduct
        /// attribute of the entry assembly.</remarks>
        public string AgentName {
            get { return agentName; }
            set { agentName = value; }
        }

        /// <summary>
        /// Gets the agent version.
        /// </summary>
        /// <remarks>Defaults to value in the AssemblyFileVersion
        /// attribute of the entry assembly.</remarks>
        public string AgentVersion {
            get { return agentVersion; }
            internal set { agentVersion = value; }
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <remarks>Defaults to value in the AssemblyProduct
        /// attribute of the entry assembly.</remarks>
        public string Author {
            get { return author; }
            internal set { author = value; }
        }


        /// <summary>
        /// Gets the add audit on ticket create option.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool CreateAuditOnNewRootJdf {
            get { return createAuditOnNewRootJdf; }
            internal set { createAuditOnNewRootJdf = value; }
        }

        /// <summary>
        /// Gets the JDF version that will be used by default.
        /// </summary>
        /// <remarks>Defaults to 1.4.</remarks>
        public string JdfVersion {
            get { return jdfVersion; }
            internal set { jdfVersion = value; }
        }

        /// <summary>
        /// Gets the default JMF sender id.  
        /// </summary>
        /// <remarks>This defaults to null.  If you
        /// do not specify a sender in configuration
        /// or pass one when you send JMF, the JMF will be invalid.</remarks>
        public string SenderId {
            get { return senderId; }
            internal set { senderId = value; }
        }

        /// <summary>
        /// Gets true if the configured default sender id is not <see langword="null"/> nor whitespace.
        /// </summary>
        public bool HasDefaultSenderId { get { return !string.IsNullOrWhiteSpace(senderId); } }

        /// <summary>
        /// Resets the configuration to default values.
        /// </summary>
        public JdfAuthoringSettings ResetToDefaults() {
            agentName = ApplicationInformation.Name;
            agentVersion = ApplicationInformation.Version;
            author = ApplicationInformation.Name;
            createAuditOnNewRootJdf = true;
            generateJobId = true;
            generateJobPartId = true;
            jdfVersion = LinqToJdf.JdfVersion.Version_1_4;
            senderId = null;
            return this;
        }
    }
}