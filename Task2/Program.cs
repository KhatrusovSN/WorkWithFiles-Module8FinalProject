Console.WriteLine("Введите путь:");
string path = Console.ReadLine();
DirectoryInfo directory = new DirectoryInfo(path);
if (directory.Exists)
{
    Console.WriteLine("Размер: " + DirectoryTotalSize.CountSize(directory)/1024 + " Кбайт");
}
else
{
    Console.WriteLine("Папки не существует");
}


class DirectoryTotalSize
{
    public static long CountSize(DirectoryInfo dir)
    {
        long size = 0;
        FileInfo[] files = dir.GetFiles();
            
        foreach (FileInfo file in files)
        {
            size += file.Length;
        }

        DirectoryInfo[] subDir = dir.GetDirectories();

        foreach (DirectoryInfo sDir in subDir)
        {
            size += CountSize(sDir);
        }
        return size;
    }
}