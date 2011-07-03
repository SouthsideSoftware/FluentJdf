<Query Kind="Program">
  <Namespace>System.Xml.Schema</Namespace>
</Query>

public static List<XmlSchemaComplexType> ProcessedComplexTypes = new List<XmlSchemaComplexType>();
public static Dictionary<string, XmlSchemaComplexType> ComplexTypes = new Dictionary<string, XmlSchemaComplexType>();

public static int level = 0;

void Main() {

	ProcessSchema();
	return;

	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\JDFProcess.xsd");
	
	var xmlDoc = new XmlDocument();
	xmlDoc.Load(path);

	var nm = new XmlNamespaceManager(xmlDoc.NameTable);
	nm.AddNamespace("jdf", "http://www.CIP4.org/JDFSchema_1_1");
	nm.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
	
	var items = new List<XmlElement>();
	
	var xPath = "./xs:complexContent/xs:extension[@base = 'jdf:JDFAbstractNode']";
	
	foreach (XmlNode element in xmlDoc.DocumentElement.ChildNodes) {
		
		if (element.Name == "xs:complexType") {
			var node = element.SelectSingleNode(xPath, nm);
			if (node != null) {	
				items.Add(element as XmlElement);
			}
		}
	}
	
	var resPoolList = new List<string>();
	var resPools = new List<KeyValuePair<string,string>>();
	
	xPath = "./xs:complexContent/xs:extension[@base = 'jdf:JDFAbstractNode']//xs:element[@name='ResourceLinkPool']/@type";
	//var attr = element.GetAttribute("name");
	foreach (XmlElement item in items.OrderBy(item => item.GetAttribute("name"))) {
		var name = item.GetAttribute("name");
		var type = item.SelectSingleNode(xPath, nm).InnerText;
		var key = new KeyValuePair<string,string>(name, type);
		if (!resPoolList.Contains(type)) {
			resPoolList.Add(type);
		}
		resPools.Add(key);
	}
		
	//print the list
	resPools.Dump();
	resPoolList.Dump();
}

public static void ProcessSchema() {

	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\JDF.xsd");

	XmlSchemaSet schemaSet = new XmlSchemaSet();

	XmlNamespaceManager nsmgr = new XmlNamespaceManager(schemaSet.NameTable);
	nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
	nsmgr.AddNamespace("jdftyp", "http://www.CIP4.org/JDFSchema_1_3_Types");
	nsmgr.AddNamespace("jdf", "http://www.CIP4.org/JDFSchema_1_1");

	schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
	schemaSet.Add("http://www.CIP4.org/JDFSchema_1_1", path);
	schemaSet.Compile();

	ComplexTypes =  (from ss in schemaSet.Schemas().Cast<XmlSchema>()
					from ct in ss.SchemaTypes.Values.OfType<XmlSchemaComplexType>()
					select ct).ToDictionary(item => item.Name);

	var lep = ComplexTypes["LayoutElementProduction"];
				
	ProcessComplexType(lep, false);
	return;
	
	foreach (XmlSchema schema in schemaSet.Schemas()) {

		foreach (var item in schema.SchemaTypes.Values) {
			var se = item as XmlSchemaComplexType;
			if (se != null) {
				WriteLine("Complex: {0}", se.Name);
			}
			else {
				var gr = item as XmlSchemaSimpleType;
				if (gr != null) {
					WriteLine("Simple : {0}", gr.Name);
				} else { 
					WriteLine("Unknown : {0}", item.GetType());
				}
			}
			//WriteLine(item.GetType());
		}

		// Iterate over each XmlSchemaElement in the Values collection
		// of the Elements property.
		foreach (XmlSchemaElement element in schema.Elements.Values) {
	
			WriteLine("Element: {0}", element.Name);
	
			// Get the complex type of the Customer element.
			XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
			
			ProcessComplexType(complexType, false);
		}
	}
}

public static void ProcessComplexType(XmlSchemaComplexType complexType, bool recurse) {
	
	XmlSchemaComplexType complexBaseType = null;
	
	var sb = new StringBuilder();
	
	if (complexType.BaseXmlSchemaType != null && complexType.BaseXmlSchemaType is XmlSchemaComplexType) {
		complexBaseType = complexType.BaseXmlSchemaType as XmlSchemaComplexType;
		sb.AppendFormat("Complex Base: {0}", complexBaseType.Name);
	} else if (complexType.BaseSchemaType != null && complexType.BaseSchemaType is XmlSchemaSimpleType) {
		sb.AppendFormat("Simple Base: {0}", (complexType.BaseSchemaType as XmlSchemaSimpleType).Name);
	} else if (complexType.BaseSchemaType != null) {
		sb.Append(complexType.BaseSchemaType.GetType());
	}

	if (recurse && ProcessedComplexTypes.Contains(complexType)) {
		sb.Append("::Type Procesed");
		WriteLine(sb.ToString());
		return;
	} else {
		WriteLine(sb.ToString());
	}

	if (!ProcessedComplexTypes.Contains(complexType)){
		ProcessedComplexTypes.Add(complexType);
	}
	
	// If the complex type has any attributes, get an enumerator 
	// and write each attribute name to the console.
	if (complexType.AttributeUses.Count > 0) {
		level++;
		IDictionaryEnumerator enumerator =
			complexType.AttributeUses.GetEnumerator();

		while (enumerator.MoveNext()) {
			XmlSchemaAttribute attribute =
				(XmlSchemaAttribute)enumerator.Value;

			WriteLine("Attribute: {0} | {1}", attribute.Name, attribute.SchemaTypeName.Name);
		}
		level--;
	}

	// Get the sequence particle of the complex type.
	XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;
	
	if (sequence != null) {
		WriteLine("{0} Begin Sequence: {1}", complexType.Name, sequence.Items.Count);
		// Iterate over each XmlSchemaElement in the Items collection.
		foreach (var childElement in sequence.Items) {
			level++;
			ProcessXmlSchemaObject(childElement);
			level--;
		}
		WriteLine("{0} End Sequence: {1}", complexType.Name, sequence.Items.Count);
	} else {
		WriteLine("No Sequence: {0}", complexType.ContentTypeParticle);
	}
	
	if (complexBaseType != null) {
		WriteLine("Process Complex Base For: {0}, {1}", complexType.Name, complexBaseType.Name);
		level++;
		WriteLine("Element Type: {0}", complexBaseType.Name);
		ProcessComplexType(complexBaseType, true);
		level--;
	}
}

public static void ProcessXmlSchemaObject(object childElement) {
	var se = childElement as XmlSchemaElement;
	if (se != null) {
		WriteLine("Element: {0}, {1}", se.Name, se.RefName.Name);
		if (se.ElementType != null) {
			var et = se.ElementType as XmlSchemaComplexType;
			if (et != null) {
				WriteLine("Element Type: {0}", et.Name);
				level++;
				ProcessComplexType(et, true);
				level--;
			} else { 
				throw new Exception("What type" + se.ElementType.GetType());
			}
		}
	}
	var gr = childElement as XmlSchemaGroupRef;
	if (gr != null) {
		WriteLine("Group Ref: {0}", gr.RefName);
	}
	var sc = childElement as XmlSchemaChoice;
	if (gr != null) {
		WriteLine("Schema Choice: {0}", sc.Id);
	}
	var ss = childElement as XmlSchemaSequence;
	if (ss != null) {
		foreach (var ssElement in ss.Items) {
			WriteLine("Schema Sequence: {0}", ssElement.GetType());
			ProcessXmlSchemaObject(ssElement);
		}
	}
	var sa = childElement as XmlSchemaAny;
	if (sa != null) {
		WriteLine("Schema XmlSchemaAny: {0}", sa.Id);
	}
}

static void WriteLine(object value) {
	Console.Write("".PadLeft(level * 4));
	Console.WriteLine(value);
}

static void WriteLine(string value) {
	Console.Write("".PadLeft(level * 4));
	Console.WriteLine(value);
}

static void WriteLine(string format, params object[] items) {
	Console.Write("".PadLeft(level * 4));
	Console.WriteLine(format, items);
}

static void ValidationCallback(object sender, ValidationEventArgs args) {
	if (args.Severity == XmlSeverityType.Warning)
		Console.Write("WARNING: ");
	else if (args.Severity == XmlSeverityType.Error)
		Console.Write("ERROR: ");

	WriteLine(args.Message);
}

// Define other methods and classes here