using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


  class Program
    {
		static IEnumerable<string> EnumerateFilesRecursively(string path)
		{ // Must have yield (or generator pattern)
			var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories); // Collects files regardless of file type

			foreach (string currentFile in files)
			{
				yield return currentFile; // Collects single file and halts until process is complete
			}
		}

		static string FormatByteSize(long byteSize)
		{
			string[] label = { "B", "KB", "MB", "GB", "TB", "PB" };

			if (byteSize == 0)
			{
				return "0" + label[0];
			}

			int place = (int)Math.Log(byteSize, 1000); // Get place of memory by converting log equation into an int

			double num = Math.Round(byteSize / Math.Pow(1000, place), 2, MidpointRounding.AwayFromZero); // Format and round number to two decimal places

			return string.Format("{0:0.00}", num) + label[place]; // Return formatted string of memory number and memory label
		}

		public static XDocument CreateReport(IEnumerable<string> files)
		{
			var table = files.GroupBy(file => new FileInfo(file).Extension.ToLower()).
		   Select(fileGroup => new {
			   Type = fileGroup.Key,
			   Count = fileGroup.Count(),
			   Size = fileGroup.Select(f => new FileInfo(f).Length).Sum()
		   }).OrderByDescending(size => size.Size);

			XDocument htmlReport = new XDocument(
				new XComment("DOCTYPE html"), // Following html format by commenting doctype
				new XElement("html", // html element
				new XElement("head", // head element
				new XElement("style",
					new XAttribute("type", "text/css"), " th, td {border: 1px solid green;}"), // style for html page, if we're ever going to use it

				new XElement("body", // body element
				new XElement("h1", "File Report"),
				new XElement("table",
					new XAttribute("style", "width: 30%"),
					new XAttribute("border", 1),
						new XElement("tr",
							new XElement("th", "Type"),
							new XElement("th", "Count"),
							new XElement("th", "Size")),

						new XElement("tr", from row in table
										   select
  new XElement("tr",
	  new XElement("td", row.Type, new XAttribute("style", "text-align:center")), // for file type
	  new XElement("td", row.Count, new XAttribute("style", "text-align:center")), // for file count
	  new XElement("td", FormatByteSize(row.Size), new XAttribute("style", "text-align:center"))))))))); // for byte count

			return htmlReport;
		}

		public static void Main(string[] args)
		{
			// Will have to use args for string command line path?
			// From what it looks like, we have to do CreateReport(EnumerateFilesRecursively(path)); , but I don't know
			// Console.WriteLine(FormatByteSize(1310000000)); //This is just a test, it works
			// args = new[] {@"C:\Users\sodac\Desktop\top secret", "document.html"};
			IEnumerable<string> files = EnumerateFilesRecursively(args[0]); // Test
			XDocument doc = CreateReport(files);
			doc.Save(args[0] + "\\" + args[1]); // Create html file, CHANGED USERNAME
												// Console.WriteLine(CreateReport(files));
												// Console.WriteLine(files);
		}
	}