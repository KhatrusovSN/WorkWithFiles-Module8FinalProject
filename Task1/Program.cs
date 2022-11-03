string path = Console.ReadLine();
DirectoryInfo dir = new DirectoryInfo(path);
if (!dir.Exists)
{
    Console.WriteLine("Такой папки не существует!");
}
else
{
    DeleteFolder(path);
}

void DeleteFolder(string path)
{
	try
	{
		DirectoryInfo directory = new DirectoryInfo(path);
		DirectoryInfo[] dir = directory.GetDirectories();
		FileInfo[] files = directory.GetFiles();

		foreach (var folder in dir)
		{
			if (DateTime.Now - folder.LastAccessTime > TimeSpan.FromMinutes(30) && folder.Exists)
			{
				DeleteFolder(folder.FullName);
			}
		}

		foreach (var file in files)
		{
			if (DateTime.Now - file.LastAccessTime > TimeSpan.FromMinutes(30) && file.Exists)
			{
				file.Delete();
			}
		}
		if (directory.GetDirectories().Length == 0 && directory.GetFiles().Length == 0)
		{
			directory.Delete();
		}
	}
	catch (Exception e)
	{

		Console.WriteLine(e.Message);
	}

    
}