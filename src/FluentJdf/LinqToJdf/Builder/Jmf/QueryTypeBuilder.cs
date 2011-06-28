namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Create commands of various types
    /// </summary>
    public partial class QueryTypeBuilder : MessageTypeBuilder {
        internal QueryTypeBuilder(JmfNodeBuilder jmfBuilder)
            : base(jmfBuilder) {
        }
    }

    //generated portion
    public partial class QueryTypeBuilder : MessageTypeBuilder {

        /// <summary>
        /// Create a Events Query
        /// </summary>
        /// <returns></returns>
        public EventsQueryBuilder Events() {
            return new EventsQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a FlushQueue Query
        /// </summary>
        /// <returns></returns>
        public FlushQueueQueryBuilder FlushQueue() {
            return new FlushQueueQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ForceGang Query
        /// </summary>
        /// <returns></returns>
        public ForceGangQueryBuilder ForceGang() {
            return new ForceGangQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a KnownControllers Query
        /// </summary>
        /// <returns></returns>
        public KnownControllersQueryBuilder KnownControllers() {
            return new KnownControllersQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a KnownDevices Query
        /// </summary>
        /// <returns></returns>
        public KnownDevicesQueryBuilder KnownDevices() {
            return new KnownDevicesQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a KnownJDFServices Query
        /// </summary>
        /// <returns></returns>
        public KnownJDFServicesQueryBuilder KnownJDFServices() {
            return new KnownJDFServicesQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a KnownMessages Query
        /// </summary>
        /// <returns></returns>
        public KnownMessagesQueryBuilder KnownMessages() {
            return new KnownMessagesQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a KnownSubscriptions Query
        /// </summary>
        /// <returns></returns>
        public KnownSubscriptionsQueryBuilder KnownSubscriptions() {
            return new KnownSubscriptionsQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a NewJDF Query
        /// </summary>
        /// <returns></returns>
        public NewJDFQueryBuilder NewJDF() {
            return new NewJDFQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a NodeInfo Query
        /// </summary>
        /// <returns></returns>
        public NodeInfoQueryBuilder NodeInfo() {
            return new NodeInfoQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a Occupation Query
        /// </summary>
        /// <returns></returns>
        public OccupationQueryBuilder Occupation() {
            return new OccupationQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a QueueEntryStatus Query
        /// </summary>
        /// <returns></returns>
        public QueueEntryStatusQueryBuilder QueueEntryStatus() {
            return new QueueEntryStatusQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a QueueStatus Query
        /// </summary>
        /// <returns></returns>
        public QueueStatusQueryBuilder QueueStatus() {
            return new QueueStatusQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a RepeatMessages Query
        /// </summary>
        /// <returns></returns>
        public RepeatMessagesQueryBuilder RepeatMessages() {
            return new RepeatMessagesQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a RequestForAuthentication Query
        /// </summary>
        /// <returns></returns>
        public RequestForAuthenticationQueryBuilder RequestForAuthentication() {
            return new RequestForAuthenticationQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a Resource Query
        /// </summary>
        /// <returns></returns>
        public ResourceQueryBuilder Resource() {
            return new ResourceQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a Status Query
        /// </summary>
        /// <returns></returns>
        public StatusQueryBuilder Status() {
            return new StatusQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a SubmissionMethods Query
        /// </summary>
        /// <returns></returns>
        public SubmissionMethodsQueryBuilder SubmissionMethods() {
            return new SubmissionMethodsQueryBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a Track Query
        /// </summary>
        /// <returns></returns>
        public TrackQueryBuilder Track() {
            return new TrackQueryBuilder(ParentJmf);
        }

    }
}