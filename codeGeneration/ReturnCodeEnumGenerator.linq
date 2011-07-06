<Query Kind="Program">
  <Reference Relative="..\src\FluentJdf\bin\Debug\FluentJdf.dll">C:\development\jwf\src\FluentJdf\bin\Debug\FluentJdf.dll</Reference>
</Query>

void Main() {
	var items = new List<Tuple<int, string ,string>>() {
	
		new Tuple<int, string ,string>(1, "GeneralError","General error"),
		new Tuple<int, string ,string>(2, "InternalError","Internal error"),
		new Tuple<int, string ,string>(3, "XMLParserError","XML parser error, (e.g., if a MIME file is sent to an XML Controller)."),
		new Tuple<int, string ,string>(4, "XMLValidationError","XML validation error"),
		new Tuple<int, string ,string>(5, "QueryOrCommandMessageNotImplemented" ,"Query Message/Command Message not implemented"),
		new Tuple<int, string ,string>(6, "InvalidParameters" ,"Invalid parameters"),
		new Tuple<int, string ,string>(7, "InsufficientParameters" ,"Insufficient parameters"),
		new Tuple<int, string ,string>(8, "DeviceNotAvailable" ,"Device not available (Controller exists but not the Device or queue)"),
		new Tuple<int, string ,string>(9, "MessageIncomplete" ,"Message incomplete."),
		new Tuple<int, string ,string>(10, "MessageServiceIsBusy" ,"Message Service is busy."),
		new Tuple<int, string ,string>(11, "SynchronousModeNotSupported" ,"Synchronous mode not supported for message. No @AcknowledgeURL is specified and the Message can only be processed asynchronously and was not processed. (Error)"),
		new Tuple<int, string ,string>(12, "AsynchronousAcknowledgeNotSupported" ,"Asynchronous acknowledge not supported for message. No @AcknowledgeURL is specified and the Message was processed. The resulting Acknowledge can only be emitted asynchronously. (Warning)"),
		new Tuple<int, string ,string>(13, "ReliableSignalsNotSupported" ,"Reliable Signals not supported. Subscription denied."),
		new Tuple<int, string ,string>(100, "DeviceNotRunning" ,"Device not running"),
		new Tuple<int, string ,string>(101, "DeviceIncapableOfFulfillingRequest" ,"Device incapable of fulfilling request, (e.g., a RIP that has been asked to cut a Sheet)."),
		new Tuple<int, string ,string>(102, "NoExecutableNodeExists" ,"No executable Node exists in the JDF"),
		new Tuple<int, string ,string>(103, "JobIDNotKnown" ,"JobID not known by Controller"),
		new Tuple<int, string ,string>(104, "JobPartIDNotKnown" ,"JobPartID not known by Controller "),
		new Tuple<int, string ,string>(105, "QueueEntryNotInQueue" ,"Queue entry not in queue"),
		new Tuple<int, string ,string>(106, "QueueRequestFailed" ,"Queue request failed because the queue entry is already executing"),
		new Tuple<int, string ,string>(107, "TheQueueEntryIsExecuting" ,"The queue entry is already executing. Late change is not accepted"),
		new Tuple<int, string ,string>(108, "SelectionOrAppliedFilterEmptyList" ,"Selection or applied filter results in an empty list"),
		new Tuple<int, string ,string>(109, "SelectionOrAppliedFilterIncompleteList" ,"Selection or applied filter results in an incomplete list. A buffer cannot provide the complete list queried for."),
		new Tuple<int, string ,string>(110, "QueueRequestFailedCompletionTime" ,"Queue request of a Job submission failed because the requested completion time of the Job cannot be fulfilled. "),
		new Tuple<int, string ,string>(111, "SubscriptionRequestDenied" ,"Subscription request denied."),
		new Tuple<int, string ,string>(112, "QueueRequestFailedClosedOrBlocked" ,"Queue request failed because the Queue is Closed or Blocked and does not accept new entries."),
		new Tuple<int, string ,string>(113, "QueueEntryAlreadyInResultingStatus" ,"Queue entry is already in the resulting status. "),
		new Tuple<int, string ,string>(114, "QueueEntryAlreadyPendingCompletedAborted" ,"QueueEntry/@Status is already \"PendingReturn\",  \"Completed\" or \"Aborted\" and therefore does not accept changes. Modification note: starting with JDF 1.4, \"PendingReturn\" added."),
		new Tuple<int, string ,string>(115, "QueueEntryIsNotRunning" ,"Queue entry is not running."),
		new Tuple<int, string ,string>(116, "QueueEntryAlreadyExists" ,"Queue entry already exists. Used when a QueueEntry with identical JobID, JobPartID and Part already exists."),
		new Tuple<int, string ,string>(120, "CannotAccessReferencedURL" ,"Cannot access referenced URL. URI Reference cannot be resolved. Used when a referenced entity, e.g., a JDF in a SubmitQueueEntry cannot be found. "),
		new Tuple<int, string ,string>(121, "UnknownDeviceID" ,"Unknown DeviceID. No Device is known with the DeviceID specified. "),
		new Tuple<int, string ,string>(130, "GangingNotSupported" ,"Ganging is not supported. A gang Job has been submitted to a queue that does not support ganging."),
		new Tuple<int, string ,string>(131, "GangNameNotKnown" ,"GangName not known. A Job has been submitted with an unknown GangName. "),
		new Tuple<int, string ,string>(200, "InvalidResourceParameters" ,"Invalid Resource parameters"),
		new Tuple<int, string ,string>(201, "InsufficientResourceParameters" ,"Insufficient Resource parameters"),
		new Tuple<int, string ,string>(202, "PipeIDUnknown" ,"PipeID unknown"),
		new Tuple<int, string ,string>(203, "UnlinkedResourceLink" ,"Unlinked ResourceLink"),
		new Tuple<int, string ,string>(204, "CouldNotCreateNewJDFNode" ,"Could not create new JDF Node. "),
		new Tuple<int, string ,string>(300, "AuthenticationDenied" ,"Authentication denied. "),
		new Tuple<int, string ,string>(301, "SecureChannelNotSupported" ,"Secure channel not supported - I don't support secure channel for this Message. "),
		new Tuple<int, string ,string>(302, "SecureChannelRequired" ,"Secure channel required - I require secure channel for this Message. "),
		new Tuple<int, string ,string>(303, "CertificateExpired" ,"Certificate expired (Some implementations might not be able to send this response because the SSL layer will reject the Message before passing it to the JMF implementation for parsing) "),
		new Tuple<int, string ,string>(304, "AuthenticationPending" ,"Authentication pending."),
		new Tuple<int, string ,string>(305, "AuthenticationAlreadyEstablished" ,"Authentication already established."),
		new Tuple<int, string ,string>(306, "NoAuthenticationRequestInProcess" ,"No authentication request in process."),
		new Tuple<int, string ,string>(307, "CertificateInvalid" ,"Certificate Invalid")
	};
	
	//Note there were so little items, the names were created by hand.
	
	var formatString = @"		
		/// <summary>
		/// {2}
		/// </summary>
		{1} = {0},";
		
		foreach (var item in items) {
			Console.WriteLine(formatString, item.Item1, item.Item2, item.Item3);
		}
	
}

// Define other methods and classes here