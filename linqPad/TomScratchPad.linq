<Query Kind="Program">
  <Reference Relative="..\src\FluentJdf\bin\Debug\Infrastructure.Core.dll">C:\development\Jwf\src\FluentJdf\bin\Debug\Infrastructure.Core.dll</Reference>
  <Reference Relative="..\src\FluentJdf\bin\Debug\FluentJdf.dll">C:\development\Jwf\src\FluentJdf\bin\Debug\FluentJdf.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Core.dll">C:\development\Jwf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Core.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Windsor.dll">C:\development\Jwf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Windsor.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Infrastructure.Container.CastleWindsor.dll">C:\development\Jwf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Infrastructure.Container.CastleWindsor.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\Infrastructure.Logging.NLog.dll">C:\development\Jwf\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\Infrastructure.Logging.NLog.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\NLog.dll">C:\development\Jwf\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\NLog.dll</Reference>
  <Namespace>FluentJdf.LinqToJdf</Namespace>
  <Namespace>Infrastructure.Container.CastleWindsor</Namespace>
  <Namespace>Infrastructure.Logging.NLog</Namespace>
</Query>

public static class TestAuthoring {
	public static XDocument GetJdf() {
		return Ticket.CreateProcessGroup().AddIntent().WithInput().BindingIntent().ValidateJdf().Ticket;
	}
}

void Main()
{
	InitializeFluentJdf();
	var ticket = TestAuthoring.GetJdf();
	ticket.Root.GetNamespaceManager().AddNamespace("xsd", Globals.XsiNamespace.NamespaceName);
	ticket.Root.GetDefaultNamespace().NamespaceName.Dump();
	ticket.Root.GetNamespaceOfPrefix("xsd").Dump();
	ticket.Dump();
	(ticket as Ticket).Errors.Dump();
	
	String xml = "<root xmlns='http://www.adventure-works.com'/>";
	var doc = XDocument.Parse(xml);
	doc.Root.GetDefaultNamespace().Dump();
	doc.Dump();
	
	doc = new XDocument(new XElement(XName.Get("foo", "fi")));
	doc.Root.GetDefaultNamespace().Dump();
	doc.Dump();
}

void InitializeFluentJdf() {
	Infrastructure.Core.Configuration.Settings.UseCastleWindsor().LogWithNLog().Configure();
}