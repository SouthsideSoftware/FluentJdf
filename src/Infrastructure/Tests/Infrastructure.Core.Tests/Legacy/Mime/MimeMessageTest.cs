using System;
using System.Drawing;
using Infrastructure.Testing;
using NUnit.Framework;
using System.IO;
using Infrastructure.Core.Mime;
using FluentAssertions;

namespace Infrastructure.Core.Tests.Legacy.Mime
{
	/// <summary>
	/// Summary description for MimeMessageTest.
	/// </summary>
	[TestFixture]
	public class MimeMessageTest {
	    string signsImagePath;
	    string mimeMultipartTextPath;
        string binaryMimeMultipartTextPath;
        string binaryChilkatMimePath;
        string mimeNestedMultipartTextPath;

        [TestFixtureSetUp]
        public void Setup() {
            signsImagePath = TestDataHelper.Instance.PathToTestFile("signs.jpg");
            mimeMultipartTextPath = TestDataHelper.Instance.PathToTestFile("mimeMultipart.txt");
            binaryMimeMultipartTextPath = TestDataHelper.Instance.PathToTestFile("binaryMimeMultipart.txt");
            binaryChilkatMimePath = TestDataHelper.Instance.PathToTestFile("binaryChilkatMime.mim");
            mimeNestedMultipartTextPath = TestDataHelper.Instance.PathToTestFile("mimeNestedMultipart.txt");
        }

		[Test]
		public void SimpleWrite()
		{
			Core.Mime.Mime message = new Core.Mime.Mime();
			message.NewMultipartRelated();

			Core.Mime.Mime message1 = new Core.Mime.Mime();
			message1.SetText("This is the time for all good men to come to the aid of their country");
			message.Add(message1);

			Core.Mime.Mime message2 = new Core.Mime.Mime();
			message2.EncodingType = Core.Mime.Mime.MimeEncoding.Base64;
			message2.SetBodyFromFile(signsImagePath);
			message.Add(message2);

			Core.Mime.Mime message3 = new Core.Mime.Mime();
			message3.EncodingType = Core.Mime.Mime.MimeEncoding.Binary;
			message3.SetBodyFromFile(signsImagePath);
			message.Add(message3);

			message.Write(File.Open(Path.Combine(Path.GetTempPath(), "TestSimpleWriteMime.txt"), FileMode.Create, FileAccess.Write, FileShare.None));

			Stream stream = File.Open(Path.Combine(Path.GetTempPath(), "TestOutPic.jpg"), FileMode.Create, FileAccess.ReadWrite);
			try
			{
				stream.Write(message2.Buffer, 0, message2.Buffer.Length);
			}
			finally 
			{
				stream.Close();
			}

			//Open the graphic
			Image i = Image.FromFile(Path.Combine(Path.GetTempPath(), "TestOutPic.jpg"));
			try {
				AssertionHelper.IsTrue("Image is 242 pixels wide", i.Width == 242);
				AssertionHelper.IsTrue("Image is 360 pixels high", i.Height == 360);
				AssertionHelper.IsTrue("Horizontal resolution is 72dpi",i.HorizontalResolution == 72);
			} 
			finally 
			{
				i.Dispose();
			}
		}

		[Test]
		public void ParseMultiPartMime() {
		    var stream = TestDataHelper.Instance.GetTestStream("mimeMultipart.txt");
			MimeParser mp = new MimeParser(stream);
			//Assuming Boundary is given.
			mp.IsMultiPart = true;
			mp.Boundary = "----_OAI_NextPart_2563710857820783";
			string sLine = "";
			bool isEOC = false;
			bool isEndOfChunk = true;
			int chunkCount = 0;
			while(sLine != null)
			{
				MimeParser.ChunkType chunkType = mp.ReadNextChunk(ref sLine, ref isEOC);
				if (sLine != null)
				{
					if (isEndOfChunk)
					{
						chunkCount++;
//						System.Diagnostics.Trace.WriteLine("Chunk no:" + chunkCount.ToString() + ".  Chunk type is " + chunkType.ToString() + ".  The chunk string is");
					}
//					System.Diagnostics.Trace.WriteLine(sLine);
				}
				isEndOfChunk = isEOC;
			}
			AssertionHelper.IsTrue("There are 13 chunks", chunkCount == 13);
		}

		[Test]
		public void ParseNestedMultiPartMime() {
		    var stream = TestDataHelper.Instance.GetTestStream("mimeNestedMultipart.txt");
			MimeParser mp = new MimeParser(stream);
			//Assuming Boundary is given.
			mp.IsMultiPart = true;
			mp.Boundary = "----_OAI_NextPart_2563710857820783";
			string sLine = "";
			bool isEOC = false;
			bool isEndOfChunk = true;
			int chunkCount = 0;
			while(sLine != null)
			{
				if (chunkCount == 5 && isEndOfChunk)
				{
					mp.Boundary = "----_OAI_NextPart_2563710857820783_FirstMessage";
				}
				else if (chunkCount == 18 && isEndOfChunk)
				{
					mp.Boundary = "----_OAI_NextPart_2563710857820783_SecondMessage";
				}
				MimeParser.ChunkType chunkType = mp.ReadNextChunk(ref sLine, ref isEOC);
				if (sLine != null)
				{
					if (isEndOfChunk)
					{
						chunkCount++;
//						System.Diagnostics.Trace.WriteLine("Chunk no:" + chunkCount.ToString() + ".  Chunk type is " + chunkType.ToString() + ".  The chunk string is");
					}
//					System.Diagnostics.Trace.WriteLine(sLine);
				}
				isEndOfChunk = isEOC;
			}
			AssertionHelper.IsTrue("There are 30 chunks",chunkCount == 30);
		}
	
		[Test]
		public void MultiPartMime() {
		    var fileName = mimeMultipartTextPath;
			Core.Mime.Mime mm = new Core.Mime.Mime(fileName);
			AssertionHelper.IsTrue("There are 3 header fields", mm.Headers.Count == 3);
			AssertionHelper.IsTrue("There are 3 parameter in the secound header field", mm.Headers[1].Parameters.Count == 3);
			AssertionHelper.IsTrue("File name of the mime message is assigned", mm.Filename.CompareTo(fileName) == 0);
			AssertionHelper.IsTrue("The content type is multipart/related", mm.ContentType.CompareTo("multipart/related") == 0);
			AssertionHelper.IsTrue("The body of the message is not xml", !mm.IsXml());
			AssertionHelper.IsTrue("There are 3 parts", mm.NumParts == 3);

			var mm1  = mm.GetPart(0);
			AssertionHelper.IsTrue("There are 1 header field and 1 parameter in the first message.", 
				mm1.Headers.Count == 1 && mm1.Headers[0].Parameters.Count == 1);
			AssertionHelper.IsTrue("The body of the first message is xml", mm1.IsXml());

			var mm2  = mm.GetPart(1);
			AssertionHelper.IsTrue("There are 1 header field and 1 parameter in the second message.", 
				mm2.Headers.Count == 1 && mm2.Headers[0].Parameters.Count == 1);
			AssertionHelper.IsTrue("The body of the second message is xml", mm2.IsXml());

			var mm3  = mm.GetPart(2);
			AssertionHelper.IsTrue("There are 4 header fields in the third message.", mm3.Headers.Count == 4);

			//Write to file
			mm.Write(File.Open(Path.Combine(Path.GetTempPath(), "TestMultiPartMimeMessage.txt"), FileMode.Create, FileAccess.Write, FileShare.None));

			//Write to file by byte
			byte [] bytes = mm.GetMimeBinary();
			Stream stream = File.Open(Path.Combine(Path.GetTempPath(), "TestMultiPartMimeMessageFromBinary.txt"), FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				stream.Write(bytes, 0, bytes.Length);
			} 
			finally 
			{
				stream.Close();
			}

			//Write to image file
			stream = File.Open(Path.Combine(Path.GetTempPath(), "TestMultipartOutPic.jpg"), FileMode.Create, FileAccess.ReadWrite);
			try
			{
				stream.Write(mm3.Buffer, 0, mm3.Buffer.Length);
			}
			finally 
			{
				stream.Close();
			}

			//Open the graphic
			Image i = Image.FromFile(Path.Combine(Path.GetTempPath(), "TestMultipartOutPic.jpg"));
			try
			{
				AssertionHelper.IsTrue("Image is 242 pixels wide", i.Width == 242);
				AssertionHelper.IsTrue("Image is 360 pixels high", i.Height == 360);
				AssertionHelper.IsTrue("Horizontal resolution is 72dpi",i.HorizontalResolution == 72);
			} 
			finally 
			{
				i.Dispose();
			}
		}

		[Test]
		public void NestedMultiPartMime()
		{
			Core.Mime.Mime mm = new Core.Mime.Mime(mimeNestedMultipartTextPath);
			AssertionHelper.IsTrue("There are 3 header fields", mm.Headers.Count == 3);
			AssertionHelper.IsTrue("There are 3 parameter in the secound header field", mm.Headers[1].Parameters.Count == 3);
			AssertionHelper.IsTrue("The content type is multipart/related", mm.GetHeaderField("content-type").CompareTo("multipart/related") == 0);
			AssertionHelper.IsTrue("There are 2 parts", mm.NumParts == 2);

			//First part
			var mm1  = mm.GetPart(0);
			AssertionHelper.IsTrue("There are 2 header fields in the first part", mm1.Headers.Count == 2);
			AssertionHelper.IsTrue("There are 1 parameter in the first header field in the first part", mm1.Headers[0].Parameters.Count == 1);
			AssertionHelper.IsTrue("There are 3 parts in the first part", mm1.NumParts == 3);

			var mm11  = mm1.GetPart(0);
			AssertionHelper.IsTrue("There are 1 header field and 1 parameter in the first message of the first part.", 
				mm11.Headers.Count == 1 && mm11.Headers[0].Parameters.Count == 1);

			var mm12  = mm1.GetPart(1);
			AssertionHelper.IsTrue("There are 1 header field and 1 parameter in the second message of the first part.", 
				mm12.Headers.Count == 1 && mm12.Headers[0].Parameters.Count == 1);

			var mm13  = mm1.GetPart(2);
			AssertionHelper.IsTrue("There are 4 header fields in the third message of the first part.",
				mm13.Headers.Count == 4);

			//Second part
			var mm2  = mm.GetPart(1);
			AssertionHelper.IsTrue("There are 2 header fields in the second part", mm2.Headers.Count == 2);
			AssertionHelper.IsTrue("There are 1 parameter in the first header field in the second part", mm2.Headers[0].Parameters.Count == 1);
			AssertionHelper.IsTrue("There are 3 parts in the second part", mm2.NumParts == 3);

			var mm21  = mm2.GetPart(0);
			AssertionHelper.IsTrue("There are 1 header field and 1 parameter in the first message of the second part.", 
				mm21.Headers.Count == 1 && mm21.Headers[0].Parameters.Count == 1);

			var mm22  = mm2.GetPart(1);
			AssertionHelper.IsTrue("There are 1 header field and 1 parameter in the second message of the second part.", 
				mm22.Headers.Count == 1 && mm22.Headers[0].Parameters.Count == 1);

			var mm23  = mm2.GetPart(2);
			AssertionHelper.IsTrue("There are 4 header fields in the third message of the second part.",
				mm23.Headers.Count == 4);

			//Write to file
			mm.Write(File.Open(Path.Combine(Path.GetTempPath(), "TestNestedMultiPartMimeMessage.txt"), FileMode.Create, FileAccess.Write, FileShare.None));
		}

		[Test]
		public void BinaryMultiPartMime()
		{
			Core.Mime.Mime mime = new Core.Mime.Mime(binaryMimeMultipartTextPath);
			AssertionHelper.IsTrue("There are 2 header fields", mime.Headers.Count == 2);
			AssertionHelper.IsTrue("There are 3 parameter in the second header field", mime.Headers[1].Parameters.Count == 3);
			AssertionHelper.IsTrue("The content type is multipart/related", mime.GetHeaderField("content-type").CompareTo("multipart/related") == 0);
			AssertionHelper.IsTrue("There are 11 parts", mime.NumParts == 11);

			AssertionHelper.IsTrue("the main mime contains content-type header.", mime.Headers.Contains("content-type"));
			AssertionHelper.IsTrue("Content-type header contains type parameter", mime.Headers["content-type"].Parameters.Contains("type"));			
			AssertionHelper.IsTrue("Content-type header contains charset parameter", mime.Headers["content-type"].Parameters.Contains("charset"));			

			if (mime.HasParts)
			{
                var p1 = mime.GetPart(0);
				AssertionHelper.IsTrue("The first body part contains content-type header with the same value as the parameter 'type' of the main mime.", 
					p1.Headers.Contains("content-type") &&
					mime.Headers["content-type"].Parameters["type"].Value.ToLower().Equals(p1.Headers["content-type"].Value.ToLower()));
			}

			string dir = Path.Combine(Path.GetTempPath(),"FluentJdfBinary");
			for (int i = 0; i < mime.NumParts; i++)
			{
				SaveToFile(dir, mime.GetPart(i), true);
			}

			mime.Write(File.Open(Path.Combine(Path.GetTempPath(), "TestBinaryMimeMultipart.txt"), FileMode.Create, FileAccess.Write, FileShare.None));
			Core.Mime.Mime outputMime = new Core.Mime.Mime(Path.Combine(Path.GetTempPath(), "TestBinaryMimeMultipart.txt"));
            try
            {
                AssertionHelper.IsTrue("There are 3 parameter in the second header field", outputMime.Headers[1].Parameters.Count == 3);
                AssertionHelper.IsTrue("The content type is multipart/related", outputMime.GetHeaderField("content-type").CompareTo("multipart/related") == 0);
                AssertionHelper.IsTrue("There are 11 parts", outputMime.NumParts == 11);
            }
            finally
            {
                outputMime.Dispose();
            }
		}

		[Test]
		public void BinaryMultiPartChilkatMime()
		{
			Core.Mime.Mime mime = new Core.Mime.Mime(binaryChilkatMimePath);
			AssertionHelper.IsTrue("There are 2 header fields", mime.Headers.Count == 2);
			AssertionHelper.IsTrue("There are 3 parameter in the second header field", mime.Headers[1].Parameters.Count == 3);
			AssertionHelper.IsTrue("The content type is multipart/related", mime.GetHeaderField("content-type").CompareTo("multipart/related") == 0);
			AssertionHelper.IsTrue("There are 4 parts", mime.NumParts == 4);

			AssertionHelper.IsTrue("the main mime contains content-type header.", mime.Headers.Contains("content-type"));
			AssertionHelper.IsTrue("Content-type header contains type parameter", mime.Headers["content-type"].Parameters.Contains("type"));			
			AssertionHelper.IsTrue("Content-type header contains charset parameter", mime.Headers["content-type"].Parameters.Contains("charset"));			

			if (mime.HasParts)
			{
				var p1 = mime.GetPart(0);
				AssertionHelper.IsTrue("The first body part contains content-type header with the same value as the parameter 'type' of the main mime.", 
					p1.Headers.Contains("content-type") &&
					mime.Headers["content-type"].Parameters["type"].Value.ToLower().Equals(p1.Headers["content-type"].Value.ToLower()));
			}

			//Change the content-transfer-encoding from base64 to binary
			for (int i = 0; i < mime.NumParts; i++)
			{
				if (mime.GetPart(i).Headers.Contains("content-transfer-encoding"))
				{
                    mime.GetPart(i).EncodingType = Core.Mime.Mime.MimeEncoding.Binary;
				}
			}

			mime.Write(File.Open(Path.Combine(Path.GetTempPath(), "TestBinaryChilkatMime.mim"), FileMode.Create, FileAccess.Write, FileShare.None));
			Core.Mime.Mime outputMime = new Core.Mime.Mime(Path.Combine(Path.GetTempPath(), "TestBinaryChilkatMime.mim"));
            try
            {
                AssertionHelper.IsTrue("There are 3 parameter in the second header field", outputMime.Headers[1].Parameters.Count == 3);
                AssertionHelper.IsTrue("The content type is multipart/related", outputMime.GetHeaderField("content-type").CompareTo("multipart/related") == 0);
                AssertionHelper.IsTrue("There are 4 parts", outputMime.NumParts == 4);

                string dir = Path.Combine(Path.GetTempPath(), "FluentJdfBinary");
                for (int i = 0; i < outputMime.NumParts; i++)
                {
                    SaveToFile(dir, outputMime.GetPart(i), false);
                }
            }
            finally
            {
                mime.Dispose();
            }
		}
		
		private void SaveToFile(string dirPath, Core.Mime.Mime mime, bool GetfileNameFromID)
		{
			//Diagnostic
			string fileName = null;
			if (GetfileNameFromID)
			{
				if (mime.Headers["content-id"] != null)
				{
					fileName = mime.Headers["content-id"].Value;
					fileName = fileName.Substring(1, fileName.Length - 2);
				}
			}
				//Get file name from content-disposition: attachment
			else
			{
				if (mime.Headers.Contains("content-disposition") 
					&& mime.Headers["content-disposition"].Value.ToLower().Equals("attachment")
					&& mime.Headers["content-disposition"].Parameters.Contains("filename"))
				{
					fileName = mime.Headers["content-disposition"].Parameters["filename"].Value;
				}
			}

			//Save file
			if (fileName != null && mime.Buffer != null)
			{
				if (!Directory.Exists(dirPath))
					Directory.CreateDirectory(dirPath);
				fileName = Path.Combine(dirPath, fileName);
				if (File.Exists(fileName))
					File.Delete(fileName);
				FileStream fs =	File.Open(fileName, FileMode.Create);
				try
				{
					fs.Write(mime.Buffer, 0, mime.Buffer.Length);
				}
				catch(Exception err)
				{
					string error = err.Message;
				}
				finally
				{
					fs.Close();
				}
			}
		}
	}
}