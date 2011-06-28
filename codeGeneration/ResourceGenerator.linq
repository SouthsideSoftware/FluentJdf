<Query Kind="Program" />

void Main() {
	
	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\JDFResource.xsd");

	var xmlDoc = new XmlDocument();
	xmlDoc.Load(path);
	
	var items = new List<string>();
	
	foreach (XmlNode element in xmlDoc.DocumentElement.ChildNodes) {
		if (element.Name == "xs:element") {
			var attr = ((XmlElement)element).GetAttribute("substitutionGroup");
			if (attr != null && attr == "jdf:Resource") {
				attr = ((XmlElement)element).GetAttribute("name");
				items.Add(attr);
			}
		}
	}
	
	//output the list
	var formatString = "public static XName {0} = Globals.JdfName(\"{0}\");";
	
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
}

// Define other methods and classes here