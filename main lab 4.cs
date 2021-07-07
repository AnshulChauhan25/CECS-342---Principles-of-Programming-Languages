static IEnumerable<string> EnumerateFilesRecursively(string path) { // Must have yield (or generator pattern)
	var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories); // Collects files regardless of file type
	
	foreach (string currentFile in files)
	{
		yield return currentFile; // Collects single file and halts until process is complete
	}
}

static string FormatByteSize(long byteSize) {
	string[] label = {"B", "KB", "MB", "GB", "TB", "PB"}; 
    
	if (byteSize == 0) {
        return "0" + label[0];
	}
    
	int place = (int)Math.Log(byteSize, 1000); // Get place of memory by converting log equation into an int
    
	double num = Math.Round(byteSize / Math.Pow(1000, place), 2, MidpointRounding.AwayFromZero); // Format and round number to two decimal places
    
	return string.Format("{0:0.00}", num) + label[place]; // Return formatted string of memory number and memory label
}

static XDocument CreateReport(IEnumerable<string> files) { // Check ordering and grouping?
	//new XElement ("customer",	new XAttribute ("id", 123), //Ignore these, these are just XML references
	//	new XElement ("firstname", "joe"),
	//	new XElement ("lastname", "bloggs",
	//		new XComment ("nice name")
	//	)
	//)
  var report = new XElement("Table",
					from f in files
					orderby f.Length
					group f by Path.GetExtension(f) into newFile
					select new
					{
						type = newFile.Key,
						count = newFile.Count(),
						size = ,
					}
				); 

			return report.Document;
}

public static void Main(string[] args) {
	// Will have to use args for string command line path?
	// From what it looks like, we have to do CreateReport(EnumerateFilesRecursively(path)); , but I don't know
	Console.WriteLine(FormatByteSize(1310000000)); //This is just a test, it works
    IEnumerable<string> files = EnumerateFilesRecursively(@"C:\Users\rom\Desktop\top secret"); // Test
	Console.WriteLine(files);
}