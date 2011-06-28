using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.LinqToJdf
{
    /// <summary>
    /// Command names
    /// </summary>
    public static class Command
    {
#pragma warning disable 1591

        public static string AbortQueueEntry = "AbortQueueEntry";
        public static string CloseQueue = "CloseQueue";
        public static string FlushQueue = "FlushQueue";
        public static string FlushResources = "FlushResources";
        public static string ForceGang = "ForceGang";
        public static string HoldQueue = "HoldQueue";
        public static string HoldQueueEntry = "HoldQueueEntry";
        public static string ModifyNode = "ModifyNode";
        public static string NewJDF = "NewJDF";
        public static string NodeInfo = "NodeInfo";
        public static string OpenQueue = "OpenQueue";
        public static string PipeClose = "PipeClose";
        public static string PipePause = "PipePause";
        public static string PipePull = "PipePull";
        public static string PipePush = "PipePush";
        public static string RemoveQueueEntry = "RemoveQueueEntry";
        public static string RequestForAuthentication = "RequestForAuthentication";
        public static string RequestQueueEntry = "RequestQueueEntry";
        public static string Resource = "Resource";
        public static string ResourcePull = "ResourcePull";
        public static string ResubmitQueueEntry = "ResubmitQueueEntry";
        public static string ResumeQueue = "ResumeQueue";
        public static string ResumeQueueEntry = "ResumeQueueEntry";
        public static string ReturnQueueEntry = "ReturnQueueEntry";
        public static string SetQueueEntryPosition = "SetQueueEntryPosition";
        public static string SetQueueEntryPriority = "SetQueueEntryPriority";
        public static string ShutDown = "ShutDown";
        public static string StopPersistentChannel = "StopPersistentChannel";
        public static string SubmitQueueEntry = "SubmitQueueEntry";
        public static string SuspendQueueEntry = "SuspendQueueEntry";
        public static string UpdateJDF = "UpdateJDF";
        public static string WakeUp = "WakeUp";

#pragma warning restore 1591

        /// <summary>
        /// Gets the xsi type for the command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string XsiType(string command) {
            return string.Format("Command{0}", command);
        }
    }
}
