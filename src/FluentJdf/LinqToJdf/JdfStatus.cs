using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.LinqToJdf {
    /// <summary>
    /// The Status attribute of JDF nodes.
    /// </summary>
    public enum JdfStatus {
        /// <summary>
        /// Invalid or unknown value.
        /// </summary>
        Unknown,
        /// <summary>
        /// Node can be executed but has not yet completed a test run.
        /// </summary>
        Waiting,
        /// <summary>
        /// The node is currently executing a test run.
        /// </summary>
        TestRunInProgress,
        /// <summary>
        /// Test run has been completed.
        /// </summary>
        Ready,
        /// <summary>
        /// Error occured during the test run.
        /// </summary>
        FailedTestRun,
        /// <summary>
        /// Process is currently being setup.
        /// </summary>
        Setup,
        /// <summary>
        /// The node is currently executing.
        /// </summary>
        InProgress,
        /// <summary>
        /// The process is currently being cleaned up.
        /// </summary>
        Cleanup,
        /// <summary>
        /// The node has been spawned into a seperate JDF.
        /// </summary>
        Spawned,
        /// <summary>
        /// Execution has been suspended.  Unlike stop, this status
        /// indicates the job has been taken off the device.
        /// </summary>
        Suspended,
        /// <summary>
        /// Execution has stopped but the job is still on the device.
        /// </summary>
        Stopped,
        /// <summary>
        /// Processing has completed properly.
        /// </summary>
        Completed,
        /// <summary>
        /// Processing has been aborted.
        /// </summary>
        Aborted,
        /// <summary>
        /// The node is processing partitions.  Details of status can be found in node info.
        /// </summary>
        Part,
        /// <summary>
        /// Deprectated in JDF 1.3.  Node is processing partitions.  Review StatusPool for more info.
        /// </summary>
        Pool

    }
}
