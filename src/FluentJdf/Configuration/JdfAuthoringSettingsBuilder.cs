using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Onpoint.Commons.Core.CodeContracts;

namespace FluentJdf.Configuration
{
    /// <summary>
    /// Fluent setting for authoring settings
    /// </summary>
    public class JdfAuthoringSettingsBuilder {
        Library library;
        JdfAuthoringSettings authoringSettingsSettings;

        internal JdfAuthoringSettingsBuilder(Library library, JdfAuthoringSettings authoringSettingsSettings) {
            ParameterCheck.ParameterRequired(library, "library");
            ParameterCheck.ParameterRequired(authoringSettingsSettings, "authoringSettingsSettings");

            this.library = library;
            this.authoringSettingsSettings = authoringSettingsSettings;
        }

        /// <summary>
        /// Gets the owning library settings.
        /// </summary>
        public Library Settings { get { return library; }}

        /// <summary>
        /// Sets option for generating job id
        /// </summary>
        /// <param name="generateJobId"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder GenerateJobId(bool generateJobId) {
            authoringSettingsSettings.GenerateJobId = generateJobId;
            return this;
        }

        /// <summary>
        /// Sets options for generating job part id.
        /// </summary>
        /// <param name="generatejobPartId"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder GenerateJobPartId(bool generatejobPartId) {
            authoringSettingsSettings.GenerateJobPartId = generatejobPartId;
            return this;
        }

        /// <summary>
        /// Sets option for the default agent name for audits.
        /// </summary>
        /// <param name="agentName"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder AgentName(string agentName) {
            authoringSettingsSettings.AgentName = agentName;
            return this;
        }

        /// <summary>
        /// Sets the default agent version for audits.
        /// </summary>
        /// <param name="agentVersion"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder AgentVersion(string agentVersion)
        {
            authoringSettingsSettings.AgentVersion = agentVersion;
            return this;
        }

        /// <summary>
        /// Sets the default author for audits.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder Author(string author)
        {
            authoringSettingsSettings.Author = author;
            return this;
        }

        /// <summary>
        /// Sets option for automatically generating a create audit on new root JDF nodes.
        /// </summary>
        /// <param name="createAuditOnNewRootJdf"></param>
        /// <returns></returns>
        public JdfAuthoringSettingsBuilder CreateAuditOnNewRootJdf(bool createAuditOnNewRootJdf)
        {
            authoringSettingsSettings.CreateAuditOnNewRootJdf = createAuditOnNewRootJdf;
            return this;
        }
    }

}
