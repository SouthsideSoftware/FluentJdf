<Query Kind="Program" />

void Main() {

	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\JDFMessage.xsd");
	
	var xmlDoc = new XmlDocument();
	xmlDoc.Load(path);

	var items = new List<string>();
	
	foreach (XmlNode element in xmlDoc.DocumentElement.ChildNodes) {
		
		if (element.Name == "xs:complexType") {
			var attr = ((XmlElement)element).GetAttribute("name");
			
			var startString = "Command";
			
			if (attr.StartsWith(startString)) {
				attr = attr.Substring(startString.Length);
				items.Add(attr);
				//Console.WriteLine(element.Name + "|" + attr);
			}
		}
	}
	
	var formatString = "public static string {0} = \"{0}\";";
	
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
}

// Define other methods and classes here