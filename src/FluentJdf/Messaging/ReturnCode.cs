using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentJdf.Messaging {
    /// <summary>
    /// JMF return codes defined by the standard
    /// </summary>
    public enum ReturnCode {

        /// <summary>
        /// Error code does not match one of the 
        /// values defined in the standard.
        /// </summary>
        Unknown = int.MinValue,

        /// <summary>
        /// Success
        /// </summary>
        Success = 0,


        /// <summary>
        /// General error
        /// </summary>
        GeneralError = 1,

        /// <summary>
        /// Internal error
        /// </summary>
        InternalError = 2,

        /// <summary>
        /// XML parser error, (e.g., if a MIME file is sent to an XML Controller).
        /// </summary>
        XMLParserError = 3,

        /// <summary>
        /// XML validation error
        /// </summary>
        XMLValidationError = 4,

        /// <summary>
        /// Query Message/Command Message not implemented
        /// </summary>
        QueryOrCommandMessageNotImplemented = 5,

        /// <summary>
        /// Invalid parameters
        /// </summary>
        InvalidParameters = 6,

        /// <summary>
        /// Insufficient parameters
        /// </summary>
        InsufficientParameters = 7,

        /// <summary>
        /// Device not available (Controller exists but not the Device or queue)
        /// </summary>
        DeviceNotAvailable = 8,

        /// <summary>
        /// Message incomplete.
        /// </summary>
        MessageIncomplete = 9,

        /// <summary>
        /// Message Service is busy.
        /// </summary>
        MessageServiceIsBusy = 10,

        /// <summary>
        /// Synchronous mode not supported for message. No @AcknowledgeURL is 
        /// specified and the Message can only be processed asynchronously and was not processed. (Error)
        /// </summary>
        SynchronousModeNotSupported = 11,

        /// <summary>
        /// Asynchronous acknowledge not supported for message. No @AcknowledgeURL is specified and the Message was processed. 
        /// The resulting Acknowledge can only be emitted asynchronously. (Warning)
        /// </summary>
        AsynchronousAcknowledgeNotSupported = 12,

        /// <summary>
        /// Reliable Signals not supported. Subscription denied.
        /// </summary>
        ReliableSignalsNotSupported = 13,

        /// <summary>
        /// Device not running
        /// </summary>
        DeviceNotRunning = 100,

        /// <summary>
        /// Device incapable of fulfilling request, (e.g., a RIP that has been asked to cut a Sheet).
        /// </summary>
        DeviceIncapableOfFulfillingRequest = 101,

        /// <summary>
        /// No executable Node exists in the JDF
        /// </summary>
        NoExecutableNodeExists = 102,

        /// <summary>
        /// JobID not known by Controller
        /// </summary>
        JobIDNotKnown = 103,

        /// <summary>
        /// JobPartID not known by Controller 
        /// </summary>
        JobPartIDNotKnown = 104,

        /// <summary>
        /// Queue entry not in queue
        /// </summary>
        QueueEntryNotInQueue = 105,

        /// <summary>
        /// Queue request failed because the queue entry is already executing
        /// </summary>
        QueueRequestFailed = 106,

        /// <summary>
        /// The queue entry is already executing. Late change is not accepted
        /// </summary>
        TheQueueEntryIsExecuting = 107,

        /// <summary>
        /// Selection or applied filter results in an empty list
        /// </summary>
        SelectionOrAppliedFilterEmptyList = 108,

        /// <summary>
        /// Selection or applied filter results in an incomplete list. A buffer cannot provide the complete list queried for.
        /// </summary>
        SelectionOrAppliedFilterIncompleteList = 109,

        /// <summary>
        /// Queue request of a Job submission failed because the requested completion time of the Job cannot be fulfilled. 
        /// </summary>
        QueueRequestFailedCompletionTime = 110,

        /// <summary>
        /// Subscription request denied.
        /// </summary>
        SubscriptionRequestDenied = 111,

        /// <summary>
        /// Queue request failed because the Queue is Closed or Blocked and does not accept new entries.
        /// </summary>
        QueueRequestFailedClosedOrBlocked = 112,

        /// <summary>
        /// Queue entry is already in the resulting status. 
        /// </summary>
        QueueEntryAlreadyInResultingStatus = 113,

        /// <summary>
        /// QueueEntry/@Status is already "PendingReturn",  "Completed" or "Aborted" and therefore does not accept changes. 
        /// Modification note: starting with JDF 1.4, "PendingReturn" added.
        /// </summary>
        QueueEntryAlreadyPendingCompletedAborted = 114,

        /// <summary>
        /// Queue entry is not running.
        /// </summary>
        QueueEntryIsNotRunning = 115,

        /// <summary>
        /// Queue entry already exists. Used when a QueueEntry with identical JobID, JobPartID and Part already exists.
        /// </summary>
        QueueEntryAlreadyExists = 116,

        /// <summary>
        /// Cannot access referenced URL. URI Reference cannot be resolved. 
        /// Used when a referenced entity, e.g., a JDF in a SubmitQueueEntry cannot be found. 
        /// </summary>
        CannotAccessReferencedURL = 120,

        /// <summary>
        /// Unknown DeviceID. No Device is known with the DeviceID specified. 
        /// </summary>
        UnknownDeviceID = 121,

        /// <summary>
        /// Ganging is not supported. A gang Job has been submitted to a queue that does not support ganging.
        /// </summary>
        GangingNotSupported = 130,

        /// <summary>
        /// GangName not known. A Job has been submitted with an unknown GangName. 
        /// </summary>
        GangNameNotKnown = 131,

        /// <summary>
        /// Invalid Resource parameters
        /// </summary>
        InvalidResourceParameters = 200,

        /// <summary>
        /// Insufficient Resource parameters
        /// </summary>
        InsufficientResourceParameters = 201,

        /// <summary>
        /// PipeID unknown
        /// </summary>
        PipeIDUnknown = 202,

        /// <summary>
        /// Unlinked ResourceLink
        /// </summary>
        UnlinkedResourceLink = 203,

        /// <summary>
        /// Could not create new JDF Node. 
        /// </summary>
        CouldNotCreateNewJDFNode = 204,

        /// <summary>
        /// Authentication denied. 
        /// </summary>
        AuthenticationDenied = 300,

        /// <summary>
        /// Secure channel not supported - I don't support secure channel for this Message. 
        /// </summary>
        SecureChannelNotSupported = 301,

        /// <summary>
        /// Secure channel required - I require secure channel for this Message. 
        /// </summary>
        SecureChannelRequired = 302,

        /// <summary>
        /// Certificate expired (Some implementations might not be able to send this response because the 
        /// SSL layer will reject the Message before passing it to the JMF implementation for parsing) 
        /// </summary>
        CertificateExpired = 303,

        /// <summary>
        /// Authentication pending.
        /// </summary>
        AuthenticationPending = 304,

        /// <summary>
        /// Authentication already established.
        /// </summary>
        AuthenticationAlreadyEstablished = 305,

        /// <summary>
        /// No authentication request in process.
        /// </summary>
        NoAuthenticationRequestInProcess = 306,

        /// <summary>
        /// Certificate Invalid
        /// </summary>
        CertificateInvalid = 307,


    }
}
