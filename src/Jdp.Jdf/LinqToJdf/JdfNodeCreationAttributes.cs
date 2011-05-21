namespace Jdp.Jdf.LinqToJdf
{
    /// <summary>
    /// Attributes that can be set when fluently creating JDF nodes.
    /// </summary>
    public class JdfNodeCreationAttributes
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public JdfNodeCreationAttributes()
        {
            JobId = Globals.CreateUniqueId("J");
        }

        /// <summary>
        /// Gets and sets the job id
        /// </summary>
        /// <remarks>The default is J_unique guid</remarks>
        public string JobId { get; set; }

        /// <summary>
        /// Gets and sets the job part id.
        /// </summary>
        public string JobPartid { get; set; }

        /// <summary>
        /// Gets and sets the descriptive name
        /// </summary>
        public string DescriptiveName { get; set; }
    }
}