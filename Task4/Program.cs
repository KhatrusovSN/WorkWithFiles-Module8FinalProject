using System.Runtime.Serialization.Formatters.Binary;

try//Создаем папку
{
    DirectoryInfo di = new DirectoryInfo("C:/Students");
    if (!di.Exists)
    {
        di.Create();
    }
}
catch (Exception e)
{
    Console.WriteLine($"Ошибка: {e}");
}
//десериализация
BinaryFormatter formatter = new BinaryFormatter();

using (var fs = new FileStream("C:/Students1/Students.dat", FileMode.OpenOrCreate))
{
    Student[] student = (Student[])formatter.Deserialize(fs);
    Console.WriteLine("Объект десериализован");

    for (int i = 0; i < student.Length; i++)
    {

        try//Создаем файл
        {
            var fileInfo = new FileInfo("C:/Students/" + student[i].Group + ".txt");
            if (!fileInfo.Exists)
            {
                using (StreamWriter sw = fileInfo.CreateText())
                {
                    sw.WriteLine($"{student[i].Name}, {student[i].DateOfBirth.ToString("dd/MM/yyyy")}");
                }
            }
            else
            {
                bool exists = false;
                using (StreamReader sr = new StreamReader("C:/Students/" + student[i].Group + ".txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains($"{student[i].Name}, {student[i].DateOfBirth.ToString("dd/MM/yyyy")}"))
                        {
                            exists = true;
                        }
                    }
                }
                if (!exists)
                {
                    using StreamWriter sw = fileInfo.AppendText();
                    sw.WriteLine($"{student[i].Name}, {student[i].DateOfBirth.ToString("dd/MM/yyyy")}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e}");
        }
    }
}

Console.ReadLine();