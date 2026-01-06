using System;

class Program
{
   public static void Main(string[] args)
    {
        string filePath = "students.txt";
        GenericFileHandler<string> handler = new GenericFileHandler<string>(filePath);
        handler.LoadFromFile();

        int choice = 0;

        do
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Update Student Marks");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            try
            {
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent(handler);
                        break;

                    case 2:
                        ViewStudents(handler);
                        break;

                    case 3:
                        SearchStudent(handler);
                        break;

                    case 4:
                        UpdateMarks(handler);
                        break;

                    case 5:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Invalid input. Try again.");
            }

        } while (choice != 5);
    }

    static void AddStudent(GenericFileHandler<string> handler)
    {
        try
        {
            Console.Write("Enter StudentId: ");
            string id = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            string age = Console.ReadLine();

            Console.Write("Enter Marks: ");
            string marks = Console.ReadLine();

            string record = $"{id},{name},{age},{marks}";
            handler.Add(record);

            Console.WriteLine("Student added successfully.");
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
    }

    static void ViewStudents(GenericFileHandler<string> handler)
    {
        Console.WriteLine("\nStudent Records:");
        foreach (var record in handler.Records)
        {
            Console.WriteLine(record);
        }
    }

    static void SearchStudent(GenericFileHandler<string> handler)
    {
        Console.Write("Enter StudentId to search: ");
        string searchId = Console.ReadLine();

        foreach (var record in handler.Records)
        {
            if (record.StartsWith(searchId + ","))
            {
                Console.WriteLine("Student Found: " + record);
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void UpdateMarks(GenericFileHandler<string> handler)
    {
        Console.Write("Enter StudentId: ");
        string id = Console.ReadLine();

        for (int i = 0; i < handler.Records.Count; i++)
        {
            string[] parts = handler.Records[i].Split(',');

            if (parts[0] == id)
            {
                Console.Write("Enter New Marks: ");
                parts[3] = Console.ReadLine();

                handler.Records[i] = string.Join(",", parts);
                handler.WriteToFile();

                Console.WriteLine("Marks updated successfully.");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void LogError(Exception ex)
    {
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("errorlog.txt", true))
        {
            sw.WriteLine($"[{DateTime.Now}] {ex.Message}");
        }
    }
}
