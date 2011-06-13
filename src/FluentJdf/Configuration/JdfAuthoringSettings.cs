using Onpoint.Commons.Core.Helpers;

namespace FluentJdf.Configuration {
    /// <summary>
    /// Settings related to authoring JDF
    /// </summary>
    public class JdfAuthoringSettings {
        string agentName;
        string agentVersion;
        string author;
        bool createAuditOnNewRootJdf = true;
        bool generateJobId;
        bool generateJobPartId;


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
        public string AgentName {
            get { return agentName; }
            set { agentName = value; }
        }

        /// <summary>
        /// Gets the agent version.
        /// </summary>
        public string AgentVersion {
            get { return agentVersion; }
            internal set { agentVersion = value; }
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public string Author {
            get { return author; }
            internal set { author = value; }
        }


        /// <summary>
        /// Gets the add audit on ticket create option.
        /// </summary>
        public bool CreateAuditOnNewRootJdf {
            get { return createAuditOnNewRootJdf; }
            internal set { createAuditOnNewRootJdf = value; }
        }

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

            return this;
        }
    }
}