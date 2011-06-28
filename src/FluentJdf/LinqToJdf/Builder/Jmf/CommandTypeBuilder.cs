using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {
    /// <summary>
    /// Create commands of various types
    /// </summary>
    public partial class CommandTypeBuilder : MessageTypeBuilder {
        internal CommandTypeBuilder(JmfNodeBuilder jmfBuilder)
            : base(jmfBuilder) {
        }
    }

    //generated portion
    public partial class CommandTypeBuilder : MessageTypeBuilder {


        /// <summary>
        /// Create a AbortQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public AbortQueueEntryCommandBuilder AbortQueueEntry() {
            return new AbortQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a CloseQueue Command
        /// </summary>
        /// <returns></returns>
        public CloseQueueCommandBuilder CloseQueue() {
            return new CloseQueueCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a FlushQueue Command
        /// </summary>
        /// <returns></returns>
        public FlushQueueCommandBuilder FlushQueue() {
            return new FlushQueueCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a FlushResources Command
        /// </summary>
        /// <returns></returns>
        public FlushResourcesCommandBuilder FlushResources() {
            return new FlushResourcesCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ForceGang Command
        /// </summary>
        /// <returns></returns>
        public ForceGangCommandBuilder ForceGang() {
            return new ForceGangCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a HoldQueue Command
        /// </summary>
        /// <returns></returns>
        public HoldQueueCommandBuilder HoldQueue() {
            return new HoldQueueCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a HoldQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public HoldQueueEntryCommandBuilder HoldQueueEntry() {
            return new HoldQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ModifyNode Command
        /// </summary>
        /// <returns></returns>
        public ModifyNodeCommandBuilder ModifyNode() {
            return new ModifyNodeCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a NewJDF Command
        /// </summary>
        /// <returns></returns>
        public NewJDFCommandBuilder NewJDF() {
            return new NewJDFCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a NodeInfo Command
        /// </summary>
        /// <returns></returns>
        public NodeInfoCommandBuilder NodeInfo() {
            return new NodeInfoCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a OpenQueue Command
        /// </summary>
        /// <returns></returns>
        public OpenQueueCommandBuilder OpenQueue() {
            return new OpenQueueCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a PipeClose Command
        /// </summary>
        /// <returns></returns>
        public PipeCloseCommandBuilder PipeClose() {
            return new PipeCloseCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a PipePause Command
        /// </summary>
        /// <returns></returns>
        public PipePauseCommandBuilder PipePause() {
            return new PipePauseCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a PipePull Command
        /// </summary>
        /// <returns></returns>
        public PipePullCommandBuilder PipePull() {
            return new PipePullCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a PipePush Command
        /// </summary>
        /// <returns></returns>
        public PipePushCommandBuilder PipePush() {
            return new PipePushCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a RemoveQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public RemoveQueueEntryCommandBuilder RemoveQueueEntry() {
            return new RemoveQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a RequestForAuthentication Command
        /// </summary>
        /// <returns></returns>
        public RequestForAuthenticationCommandBuilder RequestForAuthentication() {
            return new RequestForAuthenticationCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a RequestQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public RequestQueueEntryCommandBuilder RequestQueueEntry() {
            return new RequestQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a Resource Command
        /// </summary>
        /// <returns></returns>
        public ResourceCommandBuilder Resource() {
            return new ResourceCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ResourcePull Command
        /// </summary>
        /// <returns></returns>
        public ResourcePullCommandBuilder ResourcePull() {
            return new ResourcePullCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ResubmitQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public ResubmitQueueEntryCommandBuilder ResubmitQueueEntry() {
            return new ResubmitQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ResumeQueue Command
        /// </summary>
        /// <returns></returns>
        public ResumeQueueCommandBuilder ResumeQueue() {
            return new ResumeQueueCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ResumeQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public ResumeQueueEntryCommandBuilder ResumeQueueEntry() {
            return new ResumeQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ReturnQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public ReturnQueueEntryCommandBuilder ReturnQueueEntry() {
            return new ReturnQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a SetQueueEntryPosition Command
        /// </summary>
        /// <returns></returns>
        public SetQueueEntryPositionCommandBuilder SetQueueEntryPosition() {
            return new SetQueueEntryPositionCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a SetQueueEntryPriority Command
        /// </summary>
        /// <returns></returns>
        public SetQueueEntryPriorityCommandBuilder SetQueueEntryPriority() {
            return new SetQueueEntryPriorityCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a ShutDown Command
        /// </summary>
        /// <returns></returns>
        public ShutDownCommandBuilder ShutDown() {
            return new ShutDownCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a StopPersistentChannel Command
        /// </summary>
        /// <returns></returns>
        public StopPersistentChannelCommandBuilder StopPersistentChannel() {
            return new StopPersistentChannelCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a SubmitQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public SubmitQueueEntryCommandBuilder SubmitQueueEntry() {
            return new SubmitQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a SuspendQueueEntry Command
        /// </summary>
        /// <returns></returns>
        public SuspendQueueEntryCommandBuilder SuspendQueueEntry() {
            return new SuspendQueueEntryCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a UpdateJDF Command
        /// </summary>
        /// <returns></returns>
        public UpdateJDFCommandBuilder UpdateJDF() {
            return new UpdateJDFCommandBuilder(ParentJmf);
        }


        /// <summary>
        /// Create a WakeUp Command
        /// </summary>
        /// <returns></returns>
        public WakeUpCommandBuilder WakeUp() {
            return new WakeUpCommandBuilder(ParentJmf);
        }

    }
}
