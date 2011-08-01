<Query Kind="Program">
  <Namespace>System.Xml.Schema</Namespace>
</Query>

string basePath;
Dictionary<string, XmlSchemaComplexType> ComplexTypes = new Dictionary<string, XmlSchemaComplexType>();
Dictionary<string, string> ClassMap = new Dictionary<string,string>(); 

void Main() {
	
	basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\JDFResource.xsd");

	CreateTypeDictionary();

	var xmlDoc = new XmlDocument();
	xmlDoc.Load(path);
	
	var items = new List<string>();
	
	foreach (XmlNode element in xmlDoc.DocumentElement.ChildNodes) {
		if (element.Name == "xs:element") {
			var attr = ((XmlElement)element).GetAttribute("substitutionGroup");
			if (attr != null && attr == "jdf:Resource") {
				attr = ((XmlElement)element).GetAttribute("name");				
				items.Add(attr);
				
				var type = ((XmlElement)element).GetAttribute("type");
				var ct = ComplexTypes[type.Replace("jdf:", string.Empty)];
				
				foreach (XmlSchemaAttribute att in ct.AttributeUses.Values) {
					if (att.Name.Equals("Class", StringComparison.OrdinalIgnoreCase)) {
						ClassMap[attr] = att.FixedValue;
					}
				}
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
		public TicketResouces {0}() {{
			return new TicketResouces(_ticket, Elements.ResolveRefOrReturnResource(Resource.{0}, _child), true);
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
			var retVal = new ResourceNodeBuilder(ParentJdf, Resource.{0}, usage, id);
			retVal.Element.SetClass(""{1}"");
			return retVal;
		}}";
		
	foreach (var item in items.OrderBy (item => item)) {
		Console.WriteLine(formatString, item, ClassMap[item]);
	}
		
}

void CreateTypeDictionary() {
	var path = Path.Combine(basePath, @"..\src\FluentJdf\Resources\Schema\JDF.xsd"); //@"..\src\FluentJdf\Resources\Schema\JDF.xsd"

	XmlSchemaSet schemaSet = new XmlSchemaSet();

	XmlNamespaceManager nsmgr = new XmlNamespaceManager(schemaSet.NameTable);
	nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
	nsmgr.AddNamespace("jdftyp", "http://www.CIP4.org/JDFSchema_1_3_Types");
	nsmgr.AddNamespace("jdf", "http://www.CIP4.org/JDFSchema_1_1");

	schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
	schemaSet.Add("http://www.CIP4.org/JDFSchema_1_1", path);
	schemaSet.Compile();

	ComplexTypes = (from ss in schemaSet.Schemas().Cast<XmlSchema>()
					from ct in ss.SchemaTypes.Values.OfType<XmlSchemaComplexType>()
					select ct).ToDictionary(item => item.Name);
}

 void ValidationCallback(object sender, ValidationEventArgs args) {
	if (args.Severity == XmlSeverityType.Warning)
		Console.Write("WARNING: ");
	else if (args.Severity == XmlSeverityType.Error)
		Console.Write("ERROR: ");

	args.Message.Dump();
}
// Define other methods and classes here