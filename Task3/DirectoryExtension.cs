
internal class DirectoryExtension
{
    public static long CountSize(DirectoryInfo d)
    {
        long size = 0;
        try
        {
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += CountSize(di);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
        return size;

    }
}
