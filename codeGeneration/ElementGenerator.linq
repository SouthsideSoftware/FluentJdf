<Query Kind="Program" />

void Main() {

	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var items = new List<string>();
	var files = new string[] {"JDFCapability.xsd", "JDFCore.xsd", "JDFMessage.xsd", "JDFProcess.xsd", "JDFResource.xsd", "JDFTypes.xsd"};	
	
	foreach (var file in files) {
		var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\" + file);
		
		var xmlDoc = new XmlDocument();
		xmlDoc.Load(path);
	
		var nm = new XmlNamespaceManager(xmlDoc.NameTable);
		nm.AddNamespace("jdf", "http://www.CIP4.org/JDFSchema_1_1");
		nm.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		
		var xPath = "//xs:element";
		
		foreach (XmlNode element in xmlDoc.DocumentElement.SelectNodes(xPath, nm)) {
			var attr = ((XmlElement)element).GetAttribute("name");	
			if (!string.IsNullOrWhiteSpace(attr) && !items.Contains(attr)) {
				items.Add(attr);
			}
		}
	}
	
	var formatString = "public static XName {0} = Globals.JdfName(\"{0}\");";
	
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
}

// Define other methods and classes here