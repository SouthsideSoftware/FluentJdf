using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// Set attributes on a JDF node.
    /// </summary>
    public class JdfNodeAttributeBuilder : IJdfNodeBuilder {
        JdfNodeBuilder jdfNodeBuilder;

        internal JdfNodeAttributeBuilder(JdfNodeBuilder jdfNodeBuilder) {
            ParameterCheck.ParameterRequired(jdfNodeBuilder, "jdfNodeBuilder");

            this.jdfNodeBuilder = jdfNodeBuilder;
        }

        /// <summary>
        /// Gets the JDF node builder for this attribute builder.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder Node() {
            return jdfNodeBuilder;
        }
        /// <summary>
        /// Sets the job id.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public JdfNodeAttributeBuilder JobId(string jobId)
        {
            ParameterCheck.ParameterRequired(jobId, "jobId");

            Element.SetJobId(jobId);
            return this;
        }

        /// <summary>
        /// Sets the job part id.
        /// </summary>
        /// <returns></returns>
        public JdfNodeAttributeBuilder JobPartId(string jobPartId) {
            ParameterCheck.ParameterRequired(jobPartId, "jobPartId");

            Element.SetJobPartId(jobPartId);
            return this;
        }

        /// <summary>
        /// Create an input
        /// </summary>>
        public ResourceNodeNameBuilder WithInput() { return new ResourceNodeNameBuilder(jdfNodeBuilder, ResourceUsage.Input); }

        /// <summary>
        /// Creates an output.
        /// </summary>
        public ResourceNodeNameBuilder WithOutput() { return new ResourceNodeNameBuilder(jdfNodeBuilder, ResourceUsage.Output); }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddIntent() {
            return jdfNodeBuilder.AddIntent();
        }

        /// <summary>
        /// Adds a new intent JDF.
        /// </summary>
        /// <returns></returns>
        public JdfNodeBuilder AddProcessGroup() {
            return jdfNodeBuilder.AddProcessGroup();
        }

        /// <summary>
        /// Adds a new process JDF
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public JdfNodeBuilder AddProcess(params string[] types) {
            return jdfNodeBuilder.AddProcess(types);
        }

        /// <summary>
        /// Gets the ticket associated with this builder
        /// </summary>
        public Ticket Ticket {
            get { return jdfNodeBuilder.Ticket; }
        }

        /// <summary>
        /// Validate the JDF
        /// </summary>
        /// <param name="addSchemaInfo"></param>
        /// <returns></returns>
        public JdfNodeBuilder ValidateJdf(bool addSchemaInfo) {
            return jdfNodeBuilder.ValidateJdf(addSchemaInfo);
        }

        /// <summary>
        /// Gets the Element and allows set for inheritors
        /// </summary>
        public XElement Element {
            get { return jdfNodeBuilder.Element; }
        }

        /// <summary>
        /// Gets the container JDF builder.
        /// </summary>
        public JdfNodeBuilder ParentJdfNode {
            get { return jdfNodeBuilder.ParentJdfNode; }
        }
    }
}