using Onpoint.Commons.Core.Helpers;

namespace Jdp.Jdf.LinqToJdf.Configuration {
    /// <summary>
    /// Holds JDP settings.
    /// </summary>
    public class JdpLibrary {
        static readonly JdpLibrary settings = new JdpLibrary();
        bool addCreateAuditOnNewRootJdf = true;
        string agentName;
        string agentVersion;
        string author;

        JdpLibrary() {
            ResetToDefaults();
        }

        /// <summary>
        /// Resets the configuration to default values.
        /// </summary>
        public JdpLibrary ResetToDefaults() {
            agentName = ApplicationInformation.Name;
            agentVersion = ApplicationInformation.Version;
            author = ApplicationInformation.Name;
            addCreateAuditOnNewRootJdf = true;

            return this;
        }

        /// <summary>
        /// Gets the settings singleton.
        /// </summary>
        public static JdpLibrary Settings {
            get { return settings; }
        }

        /// <summary>
        /// Sets the agent name used when creating audits.
        /// </summary>
        /// <param name="agentName"></param>
        /// <returns></returns>
        /// <remarks>Defaults to the name of the application as set
        /// in the attributes of the entry assembly.</remarks>
        public JdpLibrary AgentNameIs(string agentName) {
            this.agentName = agentName;
            return this;
        }

        /// <summary>
        /// Gets the agent name for this configuration.
        /// </summary>
        public string AgentName { get { return agentName; } }

        /// <summary>
        /// Sets the agent version used when creating audits.
        /// </summary>
        /// <param name="agentVersion"></param>
        /// <returns></returns>
        /// <remarks>Defaults to the version of the application as set
        /// in the attributes of the entry assembly.</remarks>
        public JdpLibrary AgentVersionIs(string agentVersion) {
            this.agentVersion = agentVersion;
            return this;
        }

        /// <summary>
        /// Gets the agent version.
        /// </summary>
        public string AgentVersion{ get { return agentVersion; } }

        /// <summary>
        /// Sets the author used when creating audits.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        /// <remarks>Defaults to the name of the application as set
        /// in the attributes of the entry assembly.</remarks>
        public JdpLibrary AuthorIs(string author) {
            this.author = author;
            return this;
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public string Author { get { return author; } }

        /// <summary>
        /// Sets option that controls whether or not an
        /// audit is automatically added when the root JDF is 
        /// created.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        /// <remarks>Defaults to true.</remarks>
        public JdpLibrary AddCreateAuditOnNewRootJdfIs(bool val) {
            addCreateAuditOnNewRootJdf = val;
            return this;
        }

        /// <summary>
        /// Gets the add audit on ticket create option.
        /// </summary>
        public bool AddCreateAuditOnNewRootJdf { get { return addCreateAuditOnNewRootJdf; } }
    }
}