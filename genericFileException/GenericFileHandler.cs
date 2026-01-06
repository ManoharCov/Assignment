using System;
using System.Collections.Generic;
using System.IO;

public class GenericFileHandler<T>
{
    private List<T> records = new List<T>();
    private string filePath;

    public GenericFileHandler(string filePath)
    {
        this.filePath = filePath;
    }

    public List<T> Records => records;

    // Load data from file
    public void LoadFromFile()
    {
        try
        {
            records.Clear();

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    records.Add((T)(object)line);
                }
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    // Write data to file
    public void WriteToFile()
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                foreach (var record in records)
                {
                    writer.WriteLine(record.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    // Add record
    public void Add(T item)
    {
        records.Add(item);
        WriteToFile();
    }

    // Error Logging
    private void LogError(Exception ex)
    {
        using (StreamWriter sw = new StreamWriter("errorlog.txt", true))
        {
            sw.WriteLine($"[{DateTime.Now}] {ex.Message}");
        }
    }
}
