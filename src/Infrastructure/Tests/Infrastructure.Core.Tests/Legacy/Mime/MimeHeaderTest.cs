#if !ChilkatMime

using Infrastructure.Core.Mime;
using NUnit.Framework;

namespace Infrastructure.Core.Tests.Legacy.Mime
{
	[TestFixture]
	public class MimeHeaderTest
	{
		[Test]
		public void Basic()
		{
			MimeHeader header = new MimeHeader("name:value");
			AssertionHelper.IsTrue("Name is 'name'", header.Name == "name");
			AssertionHelper.IsTrue("Value is 'value'", header.Value == "value");
		}

		[Test]
		public void BasicWithParameters()
		{
			MimeHeader header = new MimeHeader("name:value;foo=foo;fi=fi");
			AssertionHelper.IsTrue("Name is 'name'", header.Name == "name");
			AssertionHelper.IsTrue("Value is 'value'", header.Value == "value");
			AssertionHelper.IsTrue("There are two parameters", header.Parameters.Count == 2);
			AssertionHelper.IsTrue("The fi parameter has value fi", header.Parameters["fi"].Value == "fi");
		}

		[Test]
		public void BasicWithComment()
		{
			MimeHeader header = new MimeHeader("name:val(comment)ue");
			AssertionHelper.IsTrue("Name is 'name'", header.Name == "name");
			AssertionHelper.IsTrue("Value is 'value'", header.Value == "value");
		}

		[Test]
		public void BasicWithParametersWithComment()
		{
			MimeHeader header = new MimeHeader("name:value(comment indeed);foo=(comment i..*)foo;fi=fi(comment)");
			AssertionHelper.IsTrue("Name is 'name'", header.Name == "name");
			AssertionHelper.IsTrue("Value is 'value'", header.Value == "value");
			AssertionHelper.IsTrue("There are two parameters", header.Parameters.Count == 2);
			AssertionHelper.IsTrue("The fi parameter has value fi", header.Parameters["fi"].Value == "fi");
		}

		[Test]
		[ExpectedException(typeof(MimeException))]
		public void BadLine()
		{
			MimeHeader header = new MimeHeader("name=value");
		}

		[Test]
		[ExpectedException(typeof(MimeException))]
		public void BadLineOnParameter()
		{
			MimeHeader header = new MimeHeader("name:value;foo:fi");
		}

		[Test]
		public void BasicCollection()
		{
			MimeHeaderCollection collection = new MimeHeaderCollection();
			collection.Add(new MimeHeader("name:value"));
			collection.Add(new MimeHeader("name2:value2"));
			collection.Add(new MimeHeader("name3:value3"));
			AssertionHelper.IsTrue("The value for name is value", collection["name"].Value == "value");
			AssertionHelper.IsTrue("The value for name2 is value2", collection["name2"].Value == "value2");
			AssertionHelper.IsTrue("The value for name3 is value3", collection["name3"].Value == "value3");
		}

		[Test]
		public void CollectionItemReplacement()
		{
			MimeHeaderCollection collection = new MimeHeaderCollection();
			collection.Add(new MimeHeader("name:value"));
			AssertionHelper.IsTrue("The value for name is value", collection["name"].Value == "value");
			collection.Add(new MimeHeader("name:value2"));
			AssertionHelper.IsTrue("The value for name is value2", collection["name"].Value == "value2");
		}

		[Test]
		public void CollectionItemCase()
		{
			MimeHeaderCollection collection = new MimeHeaderCollection();
			collection.Add(new MimeHeader("NAME:value2"));
			AssertionHelper.IsTrue("The value for name is value2", collection["name"].Value == "value2");
			AssertionHelper.IsTrue("The value for Name is value2", collection["Name"].Value == "value2");
		}

		[Test]
		public void CollectionEnumerator()
		{
			MimeHeaderCollection collection = new MimeHeaderCollection();
			collection.Add(new MimeHeader("name:value"));
			collection.Add(new MimeHeader("name2:value2"));
			collection.Add(new MimeHeader("name3:value3"));

			int x = 0;
			foreach (MimeHeader header in collection)
			{
				switch (x)
				{
					case 0:
						AssertionHelper.IsTrue("The header for name:value", header.Name == "name" && header.Value == "value");
						break;
					case 1:
						AssertionHelper.IsTrue("The header for name2:value2", header.Name == "name2" && header.Value == "value2");
						break;
					case 2:
						AssertionHelper.IsTrue("The header for name3:value3", header.Name == "name3" && header.Value == "value3");
						break;
					default:
						AssertionHelper.IsTrue("There are only 3 items in the collection", false);
						break;
				}
				x++;

			}
		}

		[Test]
		public void ParameterEnumerator()
		{
			MimeHeader header = new MimeHeader("name:value;p1=p1;p2=p2;p3=p3");

			int x = 0;
			foreach (MimeHeaderParam param in header.Parameters)
			{
				switch (x)
				{
					case 0:
						AssertionHelper.IsTrue("The param for p1=p1", param.Name == "p1" && param.Value == "p1");
						break;
					case 1:
						AssertionHelper.IsTrue("The param for p2=p2", param.Name == "p2" && param.Value == "p2");
						break;
					case 2:
						AssertionHelper.IsTrue("The param for p3=p3", param.Name == "p3" && param.Value == "p3");
						break;
					default:
						AssertionHelper.IsTrue("There are only 3 items in the parameters collection", false);
						break;
				}
				x++;

			}
		}
	}
}
#endif
