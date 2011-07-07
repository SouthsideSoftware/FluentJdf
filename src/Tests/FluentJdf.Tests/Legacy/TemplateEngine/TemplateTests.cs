using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentJdf.LinqToJdf;
using FluentJdf.TemplateEngine;
using Infrastructure.Core.Testing;
using NUnit.Framework;
using System.IO;
using System.Collections.Specialized;
using System.Data;

namespace FluentJdf.Tests.Legacy.TemplateEngine
{
	/// <summary>
	/// Summary description for JdfCreatorTest.
	/// </summary>
	/// 
	[TestFixture]
	public class TemplateTests
	{
		[Test]
		public void TestSimpleCreateFromTemplate()
		{
			XElement templateRoot;
			XElement generatedRoot;

			XDocument referenceTree = XDocument.Load(TestDataHelper.Instance.PathToTestFile("forTestJdfCreator.xml"));
			templateRoot = referenceTree.Root;

			var nameValues = new Dictionary<string,string>();
			nameValues.Add("IntegerSpan", "11");
			nameValues.Add("Amount1","101.36");

		    var template = new Template(TestDataHelper.Instance.PathToTestFile("sampleJDFTemplate.xml"));
		    var generated = template.Generate(nameValues, "fooey");
			generatedRoot = generated.Root;
			AssertionHelper.IsTrue("Tree created from template is currently not null", generated != null);
			AssertionHelper.IsTrue("The value of 'JobID' attribute will be 'fooey'", generatedRoot.GetJobId() == "fooey");
			AssertionHelper.IsTrue("The number of elements contained in both roots should be the same", templateRoot.Descendants().Count() == generatedRoot.Descendants().Count());

		    var templateResource = templateRoot.ResourcePoolElement().Elements().First();
            var generatedResource = generatedRoot.ResourcePoolElement().Elements().First();
            AssertionHelper.IsTrue("The number of ResourceLink that links to the first resource in the first Jdf Node should be the same", templateResource.ReferencingElements().Count() == generatedResource.ReferencingElements().Count());
            AssertionHelper.IsTrue("The resource from the template should have different id than the generated resource", templateResource.GetId() != generatedResource.GetId());

		    templateResource = templateResource.ElementsAfterSelf().First();
		    generatedResource = generatedResource.ElementsAfterSelf().First();
		    AssertionHelper.IsTrue("The number of ResourceLink that links to the second resource in the first Jdf Node should be the same", templateResource.ReferencingElements().Count() == generatedResource.ReferencingElements().Count());

		    generatedResource = generatedRoot.FirstChild().FirstChild().NextSibling().NextSibling().NextSibling().NextSibling();
		    var amount = generatedResource.GetAttributeValueAsDoubleOrNull("Amount");
		    AssertionHelper.IsTrue("The value of 'amount' attribute should be 101.36",  amount == 101.36);

		    var generatedElement = generatedRoot.FirstChild().FirstChild().NextSibling().NextSibling().NextSibling().FirstChild().NextSibling();
		    var preferedValue = generatedElement.GetAttributeValueAsIntOrNull("Preferred");
		    AssertionHelper.IsTrue("The value of 'preferred' attribute should be 11",  preferedValue == 11);

		    AssertionHelper.IsTrue("The descriptive name of the first resource should start with an I because it was generated", generatedRoot.ResourcePoolElement().FirstChild().GetDescriptiveName().Substring(0, 1) == "I");

		    AssertionHelper.IsTrue("First child of audit pool has a non-null timestamp", generatedRoot.AuditPoolElement().FirstChild().GetAttributeValueOrNull("TimeStamp") != null);
            AssertionHelper.IsTrue("First child of audit pool has a timestamp that parses properly to a date time", generatedRoot.AuditPoolElement().FirstChild().GetTimeStamp() != null);

		    AssertionHelper.IsTrue("The root node does not have a descriptive name because jdfDefault generated null", generatedRoot.GetDescriptiveName() == null);

		    AssertionHelper.IsTrue("The value of Template in the root is false", generatedRoot.IsTemplate() == false);
		}

        //[Test]
        //public void ValueOnFormula()
        //{

        //    JdfTree referenceTree = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "forTestJdfCreator.xml"));

        //    StringDictionary nameValues = new StringDictionary();
        //    nameValues.Add("IntegerSpan", "11");
        //    nameValues.Add("Amount1","101");
        //    nameValues.Add("desc1","DESC");
        //    nameValues.Add("val", "FOOL");
        //    nameValues.Add("ts", "2000-11-01T12:46:56+01:00");
        //    JdfTree generated = JdfCreator.CreateFromTemplate(Path.Combine(Config.JdpTestDataFolder, "sampleJDFTemplate.xml"), nameValues, "fooey");

        //    AssertionHelper.IsTrue("The root node has a descriptive name of DESC because a value was provided", 
        //        generated.Root.Attributes["DescriptiveName"].ToString() == "DESC");
        //    AssertionHelper.IsTrue("The first component has a descriptive name of FOOL because a value was provided", 
        //        ((JdfElement)generated.Root).ResourcePool.FirstChild.Attributes["DescriptiveName"].ToString() == "FOOL");
        //    AssertionHelper.IsTrue("The first audit has a timstamp of 2000-11-01T11:46:56Z because a value was provided", 
        //        ((JdfElement)generated.Root).AuditPool.FirstChild.Attributes["TimeStamp"].ToString() == "2000-11-01T11:46:56Z");

        //    AssertionHelper.IsTrue("The value of Template in the root is false", !((jdp.jdf.types.JdfBoolean)generated.Root.Attributes["Template"].Value).Value);
        //}

        
        //[Test]
        //public void CreateFromTemplateNoFixup()
        //{
        //    JdfElement jdfNode1;
        //    JdfElement jdfNode2;

        //    JdfTree referenceTree = new JdfTree(Path.Combine(Config.JdpTestDataFolder, "forTestJdfCreator.xml"));
        //    jdfNode1 = (JdfElement)referenceTree.Root;

        //    StringDictionary nameValues = new StringDictionary();
        //    nameValues.Add("IntegerSpan", "11");
        //    nameValues.Add("Amount1","101");
        //    JdfTree generated = JdfCreator.CreateFromTemplate(Path.Combine(Config.JdpTestDataFolder, "sampleJDFTemplate.xml"), nameValues, false);
        //    jdfNode2 = (JdfElement)generated.Root;
        //    AssertionHelper.IsTrue("Tree created from template is currently not null", generated != null);
        //    AssertionHelper.IsTrue("The number of elements contained in both roots should be the same", jdfNode1.Count == jdfNode2.Count);

        //    JdfResource resource1 = (JdfResource)(jdfNode1.FirstChild.FirstChild);
        //    JdfResource resource2 = (JdfResource)(jdfNode2.FirstChild.FirstChild);
        //    AssertionHelper.IsTrue("The number of ResourceLink that links to the first resource in the first Jdf Node should be the same", resource1.ReferencingElements.Count == resource2.ReferencingElements.Count);

        //    resource1 = (JdfResource)resource1.NextSibling;
        //    resource2 = (JdfResource)resource2.NextSibling;
        //    AssertionHelper.IsTrue("The number of ResourceLink that links to the first resource in the first Jdf Node should be the same", resource1.ReferencingElements.Count == resource2.ReferencingElements.Count);

        //    AssertionHelper.IsTrue("Both tree should have the same Validation", (jdfNode1.IsValid == jdfNode2.IsValid));
        //    AssertionHelper.IsTrue("The tree should be valid", jdfNode2.IsValid);

        //    resource1 = (JdfResource)jdfNode2.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling;
        //    string amount = resource1.Attributes["Amount"].ToString();
        //    AssertionHelper.IsTrue("The value of 'amount' attribute should be 101",  (double)resource1.Attributes["Amount"].Value == 101);

        //    Element element1 = (Element)jdfNode2.FirstChild.FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling;
        //    string preferValue = element1.Attributes["Preferred"].ToString();
        //    AssertionHelper.IsTrue("The value of 'amount' attribute should be 101",  Int32.Parse(preferValue) == 11);
        //    AssertionHelper.IsTrue("The descriptive name of the first resource should start with an I because it was generated",
        //        ((JdfElement)generated.Root).ResourcePool.FirstChild.Attributes["DescriptiveName"].ToString().Substring(0, 1) == "I");
        //    AssertionHelper.IsTrue("The ID of the first child of the resource pool should be Link0003",
        //        ((JdfElement)generated.Root).ResourcePool.FirstChild.Attributes["ID"].ToString() == "Link0003");

        //    AssertionHelper.IsTrue("First child of audit pool has a non-null timestamp", ((JdfElement)generated.Root).AuditPool.FirstChild.Attributes.IsAttributeNonNull("TimeStamp"));
        //}

        //[Test]
        //public void CreateFromTemplateWithTableNoDataSetSupplied()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, true);

        //    tree.Save("c:\\tree.xml");
        //    tree.Dump();

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("There are no QueueEntry elements", tree.Root.FirstChild.FirstChild.NextSibling.FirstChild == null);
        //    AssertionHelper.IsTrue("There are 4 nodes in the job", tree.Root.Count == 4);
        //}

        //[Test]
        //[ExpectedException(typeof(SimpleApiTemplateException))]
        //public void CreateFromTemplateIncorrectTableName()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries2");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, ds, true);
        //}

        //[Test]
        //[ExpectedException(typeof(SimpleApiTemplateException))]
        //public void CreateFromTemplateIncorrectTableStructure()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobIdSixty");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    for (int x = 0; x < 3; x++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["queueEntryId"] = x.ToString();
        //        row["queueEntryPriority"] = x.ToString();
        //        row["queueEntryStatus"] = "Waiting";
        //        row["jobPartId"] = "jobPartId";
        //        dt.Rows.Add(row);
        //    }

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, ds, true);
        //}

        //[Test]
        //public void CreateFromTemplateEmptyTable()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, ds, true);

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("There are no QueueEntry elements", tree.Root.FirstChild.FirstChild.NextSibling.FirstChild == null);
        //    AssertionHelper.IsTrue("There are 4 nodes in the job", tree.Root.Count == 4);
        //}

        //[Test]
        //public void CreateFromTemplateWithTable()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    for (int x = 0; x < 3; x++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["queueEntryId"] = x.ToString();
        //        row["queueEntryPriority"] = x.ToString();
        //        row["queueEntryStatus"] = "Waiting";
        //        row["queueEntryJobId"] = "abc1";
        //        row["jobPartId"] = "jobPartId";
        //        dt.Rows.Add(row);
        //    }

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, ds, true);

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("There are 3 QueueEntry elements", tree.Root.GetElementsByXPath("/Response/Queue/QueueEntry").Count == 3);
        //    AssertionHelper.IsTrue("There are 7 nodes in the job", tree.Root.Count == 7);
        //}

        //[Test]
        //[ExpectedException(typeof(SimpleApiTemplateException))]
        //public void CreateFromTemplateWithTableNullValueInRowCausesError()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    for (int x = 0; x < 3; x++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["queueEntryId"] = x.ToString();
        //        row["queueEntryPriority"] = x.ToString();
        //        row["queueEntryJobId"] = "abc1";
        //        row["jobPartId"] = "jobPartId";
        //        dt.Rows.Add(row);
        //    }

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, ds, true);

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("There is at least one QueueEntry element", tree.Root.FirstChild.FirstChild.NextSibling.FirstChild != null);
        //    AssertionHelper.IsTrue("There are 7 nodes in the job", tree.Root.Count == 7);
        //}

        //[Test]
        //public void CreateFromTemplateWithTableNullValueCausesDefault()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    for (int x = 0; x < 3; x++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["queueEntryId"] = x.ToString();
        //        row["queueEntryPriority"] = x.ToString();
        //        row["queueEntryStatus"] = "Waiting";
        //        row["queueEntryJobId"] = "abc1";
        //        dt.Rows.Add(row);
        //    }

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate.xml"), dict, ds, true);

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("There is at least one QueueEntry element", tree.Root.FirstChild.FirstChild.NextSibling.FirstChild != null);
        //    AssertionHelper.IsTrue("The first JobPartID of the first queue entry is 'Default'",
        //        tree.Root.GetAttributesByXPath("/Response/Queue/QueueEntry/JobPartID")[0].ToString() == "Default");
        //    AssertionHelper.IsTrue("There are 7 nodes in the job", tree.Root.Count == 7);
        //}

        //[Test]
        //public void CreateFromTemplateWithTableNullValueCausesJdfDefault()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    ds.Tables.Add(dt);

        //    for (int x = 0; x < 3; x++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["queueEntryId"] = x.ToString();
        //        row["queueEntryPriority"] = x.ToString();
        //        row["queueEntryStatus"] = "Waiting";
        //        row["queueEntryJobId"] = "abc1";
        //        dt.Rows.Add(row);
        //    }

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplate2.xml"), dict, ds, true);

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("There is at least one QueueEntry element", tree.Root.FirstChild.FirstChild.NextSibling.FirstChild != null);
        //    AttributeList list = tree.Root.GetAttributesByXPath("/Response/Queue/QueueEntry/JobPartID");
        //    AssertionHelper.IsTrue("JobPartID is null or does not exist", list[0].IsNull);
        //    AssertionHelper.IsTrue("There are 7 nodes in the job", tree.Root.Count == 7);
        //}

        //[Test]
        //public void XmlComments()
        //{
        //    JdfTree tree1 = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TemplateCommentsTest1.xml"), null, true);
        //    JdfTree tree2 = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TemplateCommentsTest1.xml"), null, true);
        //    AssertionHelper.IsTrue("Tree1 and tree2 have the same validity", tree1.Root.IsTreeValid == tree2.Root.IsTreeValid);
        //    AssertionHelper.IsTrue("Tree1 and tree2 have the same number of nodes", tree1.Root.Count == tree2.Root.Count);
        //}


        //[Test]
        //public void CreateFromTemplateWithTableDateTime()
        //{
        //    StringDictionary dict = new StringDictionary();
        //    dict.Add("queueEntryId", "entryID");
        //    dict.Add("queueEntryStatus", QueueEntry.Status.Running.ToString());
        //    dict.Add("senderId", "serverID");
        //    dict.Add("commandId", "commandID");
        //    dict.Add("deviceId", "serverID");
        //    dict.Add("queueStatus", Queue.Status.Running.ToString());

        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable("queueEntries");
        //    dt.Columns.Add("queueEntryId");
        //    dt.Columns.Add("queueEntryPriority");
        //    dt.Columns.Add("queueEntryStatus");
        //    dt.Columns.Add("queueEntryJobId");
        //    dt.Columns.Add("jobPartId");
        //    dt.Columns.Add("dateTime", typeof(DateTime));
        //    ds.Tables.Add(dt);
        //    DateTime dtVal = DateTime.Now;

        //    for (int x = 0; x < 3; x++)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["queueEntryId"] = x;
        //        row["queueEntryPriority"] = x.ToString();
        //        row["queueEntryStatus"] = "Waiting";
        //        row["queueEntryJobId"] = "abc1";
        //        row["jobPartId"] = 100;
        //        row["dateTime"] = dtVal;

        //        dt.Rows.Add(row);
        //    }

        //    JdfTree tree = JdfCreator.CreateFromTemplate(
        //        Path.Combine(Config.JdpTestDataFolder, @"TestTableTemplateWithDate.xml"), dict, ds, true);

        //    AssertionHelper.IsTrue("The tree is valid", tree.Root.IsTreeValid);
        //    ElementList list = tree.Root.GetElementsByXPath("/Response/Queue/QueueEntry");
        //    AssertionHelper.IsTrue("There are 3 QueueEntry elements", list.Count == 3);
        //    AssertionHelper.IsTrue("There are 7 nodes in the job", tree.Root.Count == 7);

        //    if (typeCatalogVersion == 1)
        //    {
        //        AssertionHelper.IsTrue("The value of the StartTime in the first entry is as expected",
        //            (JdfDateTime)list[0].Attributes["StartTime"].Value == dtVal);
        //    }
        //    else
        //    {
        //        AssertionHelper.IsTrue("The value of the StartTime in the first entry is as expected",
        //            (JdfDateTimeEx)list[0].Attributes["StartTime"].Value == dtVal);
        //    }
        //}

	}
}
