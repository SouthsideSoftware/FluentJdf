<Query Kind="Program" />

void Main() {

	var basePath = new FileInfo(Util.CurrentQueryPath).DirectoryName;
	var path = Path.Combine(basePath,  @"..\src\FluentJdf\Resources\Schema\JDFMessage.xsd");
	
	var xmlDoc = new XmlDocument();
	xmlDoc.Load(path);

	var comamnd = new List<string>();
	var query = new List<string>();
	
	var commandString = "Command";
	var queryString = "Query";
	
	foreach (XmlNode element in xmlDoc.DocumentElement.ChildNodes) {
		
		if (element.Name == "xs:complexType") {
			var attr = ((XmlElement)element).GetAttribute("name");
			
			if (attr.StartsWith(commandString)) {
				attr = attr.Substring(commandString.Length);
				comamnd.Add(attr);
			}
			else if (attr.StartsWith(queryString)) {
				attr = attr.Substring(queryString.Length);
				query.Add(attr);
			}
		}
	}
	
	//{0} = Name == SubmitQueueEntry
	//{1} = Type == Command or Query
	//{2} = Prefix == SQE_
	var formatCommandBuilder = @"
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {{
	/// <summary>
	/// Used to build {0}
	/// </summary>
	public class {0}{1}Builder : {1}Builder {{
		internal const string IdPrefix = ""{2}_"";

		internal {0}{1}Builder(JmfNodeBuilder parent)
			: base(parent, {1}.{0}, IdPrefix) {{
			ParameterCheck.ParameterRequired(parent, ""parent"");
		}}

		/// <summary>
		/// Gets the attribute builder.
		/// </summary>
		/// <returns></returns>
		public {0}{1}AttributeBuilder With() {{
			return new {0}{1}AttributeBuilder(this);
		}}
	}}
}}
";

	//{0} = Name == SubmitQueueEntry
	//{1} = Type == Command or Query

	var formatCommandAttributeBuilder = @"
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {{
	/// <summary>
	/// Build attributes for {0}{1}Builder.
	/// </summary>
	public class {0}{1}AttributeBuilder : JmfAttributeBuilderBase {{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name=""builder""></param>
		internal {0}{1}AttributeBuilder({0}{1}Builder builder)
			: base(builder) {{
		}}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name=""name""></param>
		/// <param name=""value""></param>
		/// <returns></returns>
		public {0}{1}AttributeBuilder Attribute(XName name, string value) {{
			ParameterCheck.ParameterRequired(name, ""name"");

			Element.SetAttributeValue(name, value);
			return this;
		}}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name=""id""></param>
		/// <returns></returns>
		public {0}{1}AttributeBuilder Id(string id) {{

			Element.SetAttributeValue(""ID"", id);
			return this;
		}}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public {0}{1}AttributeBuilder UniqueId() {{
			return Id(Globals.CreateUniqueId({0}{1}Builder.IdPrefix));
		}}
		
		/// <summary>
		/// Add a JDF that will be sent with this submit queue entry.
		/// </summary>
		/// <param name=""ticket""></param>
		/// <returns></returns>
		public {0}{1}AttributeBuilder Ticket(Ticket ticket) {{
			ParameterCheck.ParameterRequired(ticket, ""ticket"");
		
			ParentJmfNode.Message.AssociatedTicket = ticket;
			return this;
		}}
	}}
}}

";	



	//{0} = Name == SubmitQueueEntry
	//{1} = Type == Command or Query

	var formatQueryAttributeBuilder = @"
using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.LinqToJdf.Builder.Jmf {{
	/// <summary>
	/// Build attributes for {0}{1}Builder.
	/// </summary>
	public class {0}{1}AttributeBuilder : JmfAttributeBuilderBase {{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name=""builder""></param>
		internal {0}{1}AttributeBuilder({0}{1}Builder builder)
			: base(builder) {{
		}}

		/// <summary>
		/// Sets any attribute.
		/// </summary>
		/// <param name=""name""></param>
		/// <param name=""value""></param>
		/// <returns></returns>
		public {0}{1}AttributeBuilder Attribute(XName name, string value) {{
			ParameterCheck.ParameterRequired(name, ""name"");

			Element.SetAttributeValue(name, value);
			return this;
		}}

		/// <summary>
		/// Set the id.
		/// </summary>
		/// <param name=""id""></param>
		/// <returns></returns>
		public {0}{1}AttributeBuilder Id(string id) {{

			ParentJmfNode.Element.SetAttributeValue(""ID"", id);
			return this;
		}}

		/// <summary>
		/// Sets a unique id
		/// </summary>
		/// <returns></returns>
		public {0}{1}AttributeBuilder UniqueId() {{
			return Id(Globals.CreateUniqueId({0}{1}Builder.IdPrefix));
		}}
	}}
}}

";	

var formatMethodCall = @"
/// <summary>
/// Create a {0} {1}
/// </summary>
/// <returns></returns>
public {0}{1}Builder {0}() {{
	return new {0}{1}Builder(ParentJmf);
}}
";

	var saveRootPath = Path.Combine(basePath, "output");
	
	if (!Directory.Exists(saveRootPath)) {
		Directory.CreateDirectory(saveRootPath);
	}
	
	foreach (var file in Directory.GetFiles(saveRootPath)) {
		File.Delete(file);
	}

	//return;
	
	foreach (var item in comamnd.OrderBy (item => item)) {
		var type = "Command";
		Console.WriteLine(formatMethodCall, item, type);
		var mainPath = Path.Combine(saveRootPath, string.Format("{0}{1}Builder.cs",  item, type));
		var attributePath = Path.Combine(saveRootPath, string.Format("{0}{1}AttributeBuilder.cs",  item, type));
		//Console.WriteLine(formatCommandBuilder, item, type, GetUpperCaseCharacters(item));
		File.WriteAllText(mainPath, string.Format(formatCommandBuilder, item, type, GetUpperCaseCharacters(item)));
		//Console.WriteLine(formatAttributeBuilder, item, type, GetUpperCaseCharacters(item));
		File.WriteAllText(attributePath, string.Format(formatCommandAttributeBuilder, item, type, GetUpperCaseCharacters(item)));
	}
	
	foreach (var item in query.OrderBy (item => item)) {
		var type = "Query";
		Console.WriteLine(formatMethodCall, item, type);
		var mainPath = Path.Combine(saveRootPath, string.Format("{0}{1}Builder.cs",  item, type));
		var attributePath = Path.Combine(saveRootPath, string.Format("{0}{1}AttributeBuilder.cs",  item, type));
		//Console.WriteLine(formatCommandBuilder, item, type, GetUpperCaseCharacters(item));
		File.WriteAllText(mainPath, string.Format(formatCommandBuilder, item, type, GetUpperCaseCharacters(item)));
		//Console.WriteLine(formatAttributeBuilder, item, type, GetUpperCaseCharacters(item));
		File.WriteAllText(attributePath, string.Format(formatQueryAttributeBuilder, item, type, GetUpperCaseCharacters(item)));
	}
}

public static string GetUpperCaseCharacters(string value) {
	var retVal = new StringBuilder();
	
	foreach (char c in value) {
		if (char.IsUpper(c)){
			retVal.Append(c);
		}	
	}
	return retVal.ToString();
}

// Define other methods and classes here