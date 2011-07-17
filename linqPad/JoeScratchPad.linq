<Query Kind="Program">
  <Reference Relative="..\src\FluentJdf\bin\Debug\Infrastructure.Core.dll">C:\development\fluentjdf\src\FluentJdf\bin\Debug\Infrastructure.Core.dll</Reference>
  <Reference Relative="..\src\FluentJdf\bin\Debug\FluentJdf.dll">C:\development\fluentjdf\src\FluentJdf\bin\Debug\FluentJdf.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Core.dll">C:\development\fluentjdf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Core.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Windsor.dll">C:\development\fluentjdf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Windsor.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Infrastructure.Container.CastleWindsor.dll">C:\development\fluentjdf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Infrastructure.Container.CastleWindsor.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\Infrastructure.Logging.NLog.dll">C:\development\fluentjdf\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\Infrastructure.Logging.NLog.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\NLog.dll">C:\development\fluentjdf\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\NLog.dll</Reference>
  <Namespace>FluentJdf.LinqToJdf</Namespace>
  <Namespace>Infrastructure.Container.CastleWindsor</Namespace>
  <Namespace>Infrastructure.Logging.NLog</Namespace>
  <Namespace>FluentJdf.Configuration</Namespace>
  <Namespace>NLog.Config</Namespace>
  <Namespace>NLog.Targets</Namespace>
  <Namespace>FluentJdf.Encoding</Namespace>
  <Namespace>Infrastructure.Core.Testing</Namespace>
  <Namespace>Infrastructure.Core.Helpers</Namespace>
  <Namespace>Infrastructure.Core.Mime</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>FluentJdf.Transmission</Namespace>
  <Namespace>FluentJdf.Messaging</Namespace>
</Query>

bool loggingOn = false;
static ITransmitter mockTransmitter;

//static IEncoding defaultEncoding;
//static IEncoding defaultSinglePartEncoding;
//static IEncoding defaultMultiPartEncoding;

void Main() {
	InitializeFluentJdf();
	//ProcessTicketsForTests();
	//FactoryTests();
	//FluentGetProcess();
	//FluentSubmitQueueEntry();
	InitializeFileEncodingTransmitters();
}

void InitializeFileEncodingTransmitters() {

	FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings()
	.FileTransmitterEncoder("id", @"file:///c:\temp\SimpleSend\MimeEncoded\", true)
	.FileTransmitterEncoder("id2", @"file:///c:\zzz\SimpleSend\MimeEncoded\")
	.FolderInfo(FolderInfoTypeEnum.Attachment, @"file:///c:\zzz\SimpleSend\dest\", @"file:///c:\zzz\SimpleSend\ref\")
	.Settings.EncodingSettings.FileTransmitterEncoders.Dump();

}

void FluentGetProcess() {
//var xn = XName.Get(ProcessType.Bending);
	//xn.LocalName.Dump();
	//xn.Dump();
	
	var ticket = FluentJdf.LinqToJdf.Ticket
			.CreateProcess(ProcessType.Bending, ProcessType.CaseMaking)
			//.AddProcess(ProcessType.Buffer)
			//.AddIntent()

			.WithInput()
			.RunList()
			.AddNode(Resource.FileSpec).With().Attribute("Url", "Foo")
			.WithInput()
			.RunList()
			.WithInput()
			.LayoutElement()
			.WithInput()
			.FileSpec()
			.WithOutput()
			//how do I get to the run list this references fluently? (By Calling RunList)
			.InkZoneProfile().AddNode(Resource.RunList.RefName()).With().Attribute("rRef", "foo")
			.WithInput().RunList().With().Id("foo")
			.AddProcessGroup()
			//.BindingIntent()
			.AddNode(new XElement("AddressChild"))
			.With()
			.Attribute("addressid", "1234").Ticket;
	
	//ticket.Dump();
	
	ticket.GetProcess()
	.Bending().Dump("Bending")
	.WithOutput().Dump("WithOutput")
	.InkZoneProfile().Dump("InkZoneProfile")
	.RunList().Dump("RunList");
	
	ticket.GetProcess()
	.Bending()
	.WithInput()
	.LayoutElement().Dump("LayoutElement With Fluent Name");
	
	ticket.GetProcess()
	.Bending()
	.WithInput()
	.Named(Element.LayoutElement)
	.Dump("LayoutElement With XName");

	ticket.GetProcess()
	.Bending()
	.WithInput()
	.Named("LayoutElement")
	.Dump("LayoutElement With String");
	
	//.WithInput("LayoutElement").Dump()
	//.WithOutput("InkZoneProfile").Dump()
	//.WithInput()
	//.Dump();
	
	var intent = Ticket.CreateIntent().WithInput().ArtDeliveryIntent().Ticket;
	
	//intent.GetIntent().WithInput().ArtDeliveryIntent().Dump();
	
	intent = Ticket.CreateIntent().WithInput()
	.ArtDeliveryIntent().AddNode("ArtDelivery").AddNode(Resource.RunList).Ticket.Dump("ArtDelivery");
	
	intent.GetIntent().WithInput().ArtDeliveryIntent().RunList().Dump("RunList");
	
	//intent = Ticket.CreateIntent().WithInput().ArtDeliveryIntent().AddNode(Element.ArtDelivery).AddNode(Resource.RunList).Ticket;
 	//intent.GetIntent().WithInput().ArtDeliveryIntent().RunList().Dump();
}

void FactoryTests() {
	FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
	var factory = new FluentJdf.Encoding.EncodingFactory();

	FluentJdf.Configuration.FluentJdfLibrary.Settings.WithEncodingSettings()
	.DefaultSinglePartEncoding<MimeEncoding>()
	.DefaultMultiPartEncoding<MimeEncoding>()
	.EncodingForMimeType<MimeEncoding>("multipart/related");
	//

	//defaultEncoding = factory.GetEncodingForMimeType("xxx");
	//defaultSinglePartEncoding = factory.GetDefaultEncodingForSinglePart();
	//defaultMultiPartEncoding = new MimeEncoding();

	factory.GetDefaultEncodingForMultiPart().Dump();
	
	//var stream = new FluentJdf.Encoding.MessageTransmissionPart(Message.Create().Element.Document, "test").CopyOfStream();
	
	//var originalStreamLength = stream.Length;
	
	//TODO fix hard coded path.
	var path = @"C:\development\fluentjdf\src\Infrastructure\Tests\Infrastructure.Core.Tests\TestData\mimeMultipart.txt";
	 
	ITransmissionPartFactory transmissionPartFactory = new TransmissionPartFactory();
	
	using (var stream = File.OpenRead(path)) {
	
		var parts = new FluentJdf.Encoding.MimeEncoding(transmissionPartFactory).Decode("test", stream, MimeTypeHelper.MimeMultipartMimeType);
		parts.Dump();
		
		using (var bmp = new Bitmap(parts.Last().CopyOfStream())) {
			bmp.Dump();
		}
		
		//now lets reverse the process.
		
		var encoded = new FluentJdf.Encoding.MimeEncoding(transmissionPartFactory).Encode(parts);
		
		parts = new FluentJdf.Encoding.MimeEncoding(transmissionPartFactory).Decode("test", encoded.Stream, MimeTypeHelper.MimeMultipartMimeType);
		parts.Dump();
		
		parts.Last().CopyOfStream().Length.Dump();
		
		using (var bmp = new Bitmap(parts.Last().CopyOfStream())) {
			bmp.Dump();
		}
		
		encoded.Stream.Position = 0;
		
		using (var sr = new StreamReader(encoded.Stream)) {
			sr.ReadToEnd().Dump();
		}
		
	}
}


void InitializeFluentJdf() {
	var config = Infrastructure.Core.Configuration.Settings.UseCastleWindsor();
	if (loggingOn){
		config.LogWithNLog(GetNLogConfiguration());
	}
	config.Configure();
	FluentJdfLibrary.Settings.ResetToDefaults();
	
	Infrastructure.Core.Configuration.Settings.ServiceLocator.LogRegisteredComponents();
	mockTransmitter = new MockTransmitter();
	//var trans = Infrastructure.Core.Configuration.Settings.ServiceLocator.Resolve<IHttpWebRequestFactory>().Dump();
	
}

LoggingConfiguration GetNLogConfiguration(){
	LoggingConfiguration config = new LoggingConfiguration();
	
	ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
	config.AddTarget("console", consoleTarget);
	consoleTarget.Layout = "${longdate} ${level:uppercase=true} ${logger} ${newline}${message}${newline}";
	LoggingRule rule = new LoggingRule("*", NLog.LogLevel.Debug, consoleTarget);
	config.LoggingRules.Add(rule);
	
	return config;
}

static void ProcessTicketsForTests() {
var ticket = FluentJdf.LinqToJdf.Ticket
			.CreateIntent()
			.Ticket
	
	
	
			.ModifyJdfNode()
			.WithInput()
			.Address()
			.AddNode(new XElement("AddressChild"))
			.With()
			.Attribute("addressid", "1234").Ticket;
			
	/*
			.AddNode("Test")
			.With()
			.Attribute("me", "4")	
	*/		
			
	//ticket.Dump();

	//ticket.SelectJDFDescendant("Address").Element("AddressChild").Dump();

	ticket = FluentJdf.LinqToJdf.Ticket
		.CreateIntent()
		.Ticket
		.ModifyJdfNode()
		//.AddNode(new XElement("Test"))
		//.With()
		//.Attribute("me", "4")
		.AddIntent()
		.AddNode("Test")
		.With()
		.Attribute("me", "6")
		.WithInput()
		.Address()
		.AddNode("AddressChild")
		.With()
		.Attribute("addressid", "1234")
		.AddIntent()
		.AddNode("Test")
		.With()
		.Attribute("me", "8").Ticket;
	
	//ticket.Dump();


	ticket.Root.Dump().SelectJDFDescendant("JDF").Dump().Element("Test").Dump();//.Attribute("me").Value.Equals("6").Dump();
}

//issue 65
void FluentSubmitQueueEntry() {
	FluentJdf.LinqToJdf.Message message;
	FluentJdf.LinqToJdf.Ticket ticket;

	ticket = FluentJdf.LinqToJdf.Ticket.CreateIntent().Ticket;
	message = FluentJdf.LinqToJdf.Message.Create().AddCommand().SubmitQueueEntry().With().Ticket(ticket).Message;

	message.Dump();

 	FluentJdf.Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
	FluentJdf.Configuration.FluentJdfLibrary.Settings.WithTransmitterSettings().TransmitterForScheme("file", typeof(MockTransmitter));
	message.Transmit("file:///Test");

}

 public class MockTransmitter : ITransmitter {
	#region ITransmitter Members

	public IJmfResult Transmit(Uri uri, ITransmissionPartCollection partsToSend) {
		var result = new JmfResult(partsToSend);
		result.Dump();
		
		var encoded = new FluentJdf.Encoding.MimeEncoding(new TransmissionPartFactory()).Encode(partsToSend);
		encoded.Stream.Position = 0;
		
		using (var sr = new StreamReader(encoded.Stream)) {
			sr.ReadToEnd().Dump();
		}
		
		return result;
	}

	public IJmfResult Transmit(string uri, ITransmissionPartCollection partsToSend) {
		throw new NotImplementedException();
	}

	#endregion
}

/*
	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var ticket = FluentJdf.LinqToJdf.Ticket.Load(Path.Combine(basePath, @"..\src\Tests\FluentJdf.Tests\TestData\ProcessTwoMediaFiery.jdf"));

	//ticket.Dump();
	
	var reader = XmlReader.Create(new StringReader(ticket.ToString()));
	var nameTable = reader.NameTable;
	var namespaceManager = new XmlNamespaceManager(nameTable);
	namespaceManager.AddNamespace("ns", "http://www.CIP4.org/JDFSchema_1_1");
	
	var node = ticket.XPathSelectElement("//ns:ResourceLinkPool", namespaceManager);
	//node.Dump();
	
	var jdf = node.XPathSelectElements("//ns:JDF", namespaceManager);
	
	//jdf.Dump();

	var pt = node.GetJdfNodesContainingProcessType("DigitalPrinting");
	//pt.Dump();

	foreach (var element in pt) {
		var link = element.GetResourceLinkPoolResolvedItem("DigitalPrintingParams", ResourceUsage.Input);
		//link.Dump();
		
	}
	
	var toParse = "process:DigitalPrinting/DigitalPrintingParams[@usage=input]/./DigitalPrintingParams/Media"; //;/./DigitalPrintingParams
	
	var parse = FluentJdf.LinqToJdf.ProcessXPathParser.Parse(toParse);
	parse.Dump();
	
	//ticket.DenormalizeRefElements();
	//ticket.Dump();
	//ticket.RenormalizeRefElements();
	
	var results = ticket.ProcessXPathSelectElements(toParse);
	
	results.Dump();

*/

// Define other methods and classes here
/*

	var toParse = "process:DigitalPrinting/DigitalPrintingParams"; //"process:DigitalPrinting/DigitalPrintingParams[@usage=output]/./rest";
	var parse = FluentJdf.LinqToJdf.ProcessXPathParser.Parse(toParse);
	parse.Dump();


*/