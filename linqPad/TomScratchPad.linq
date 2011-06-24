<Query Kind="Program">
  <Reference Relative="..\src\FluentJdf\bin\Debug\Infrastructure.Core.dll">C:\development\jwf\src\FluentJdf\bin\Debug\Infrastructure.Core.dll</Reference>
  <Reference Relative="..\src\FluentJdf\bin\Debug\FluentJdf.dll">C:\development\jwf\src\FluentJdf\bin\Debug\FluentJdf.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Core.dll">C:\development\jwf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Core.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Windsor.dll">C:\development\jwf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Castle.Windsor.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Infrastructure.Container.CastleWindsor.dll">C:\development\jwf\src\Infrastructure\Infrastructure.Container.CastleWindsor\bin\Debug\Infrastructure.Container.CastleWindsor.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\Infrastructure.Logging.NLog.dll">C:\development\jwf\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\Infrastructure.Logging.NLog.dll</Reference>
  <Reference Relative="..\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\NLog.dll">C:\development\jwf\src\Infrastructure\Infrastructure.Logging.NLog\bin\Debug\NLog.dll</Reference>
  <Namespace>FluentJdf.LinqToJdf</Namespace>
  <Namespace>Infrastructure.Container.CastleWindsor</Namespace>
  <Namespace>Infrastructure.Logging.NLog</Namespace>
  <Namespace>FluentJdf.Configuration</Namespace>
  <Namespace>NLog.Config</Namespace>
  <Namespace>NLog.Targets</Namespace>
</Query>

static Ticket GetJdf() {
	return Ticket.CreateProcessGroup().AddIntent().WithInput().BindingIntent().ValidateJdf().Ticket;
}
	
static Message GetJmf() {
	return Message.Create().AddCommand().SubmitQueueEntry().ValidateJmf().Message;
}

//Log messages are written to /logs/FluentJdf.LinqPad/general.log
void Main()
{
	InitializeFluentJdf();
	
	var ticket = GetJdf().Dump();
	ticket.ValidationMessages.Dump();
	"*****************".Dump();
	
	var message = GetJmf().Dump();
	message.ValidationMessages.Dump();
	"*****************".Dump();
}

void InitializeFluentJdf() {
	Infrastructure.Core.Configuration.Settings.UseCastleWindsor().LogWithNLog(GetNLogConfiguration()).Configure();
	Library.Settings.ResetToDefaults();
}

LoggingConfiguration GetNLogConfiguration(){
	LoggingConfiguration config = new LoggingConfiguration();
	
	FileTarget fileTarget = new FileTarget();
	config.AddTarget("file", fileTarget);
	fileTarget.Layout = "${longdate} ${level:uppercase=true} ${logger} ${newline}${message}${newline}";
	fileTarget.DeleteOldFileOnStartup = true;
	fileTarget.KeepFileOpen = true;
	fileTarget.FileName = "/logs/FluentJdf.LinqPad/general.log";
	LoggingRule rule = new LoggingRule("*", NLog.LogLevel.Debug, fileTarget);
	config.LoggingRules.Add(rule);
	
	return config;
}