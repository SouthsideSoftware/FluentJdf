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
	
	//output the list of XNames
	var formatString = "public static XName {0} = Globals.JdfName(\"{0}\");";
	
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
	
	formatString = @"		
		/// <summary>
		/// {0}
		/// </summary>
		/// <returns></returns>
		public IEnumerable<XElement> {0}() {{
			return Elements.Where(item => item.Name == Resource.{0});
		}}";
	
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
	
	Console.WriteLine("");
	Console.WriteLine("Generate ResourceNodeNameBuilder.cs");
	Console.WriteLine("");
	
	formatString = @"
		/// <summary>
		/// Create a {0} and return a builder to operate on it.
		/// </summary>
		/// <param name=""id"">An optional id, otherwise a unique id will be created</param>
		public ResourceNodeBuilder {0}(string id = null) {{
			return new ResourceNodeBuilder(ParentJdf, Resource.{0}, usage, id);
		}}";
		
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item);
	}
		
}

// Define other methods and classes here