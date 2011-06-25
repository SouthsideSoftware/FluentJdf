<Query Kind="Program" />

void Main() {
	var path = @"C:\development\jwf\src\FluentJdf\Resources\Schema\JDFProcess.xsd";
	
	var xmlDoc = new XmlDocument();
	xmlDoc.Load(path);

	var nm = new XmlNamespaceManager(xmlDoc.NameTable);
	nm.AddNamespace("jdf", "http://www.CIP4.org/JDFSchema_1_1");
	nm.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
	
	var items = new List<string>();
	
	var xPath = "./xs:complexContent/xs:extension[@base = 'jdf:JDFAbstractNode']";
	
	foreach (XmlNode element in xmlDoc.DocumentElement.ChildNodes) {
		
		if (element.Name == "xs:complexType") {
			var attr = ((XmlElement)element).GetAttribute("name");
			//Console.WriteLine(element.Name + "|" + attr);	
			var node = element.SelectSingleNode(xPath, nm);
			
			if (node != null) {	
				items.Add(attr);
			}
		}
	}
	
	var formatString = "public static string {0} = \"{0}\";";
	
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
}

// Define other methods and classes here