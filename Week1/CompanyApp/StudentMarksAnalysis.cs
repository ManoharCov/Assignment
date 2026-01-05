using System;

class StudentMarksAnalysis
{
    public static void MarksAnalysis()
    {
        int[] marks = { 78, 45, 32, 90, 66, 39, 81 };

        int highest = marks[0];
        int lowest = marks[0];
        int passCount = 0;

        foreach (int mark in marks)
        {
            if (mark > highest)
                highest = mark;

            if (mark < lowest)
                lowest = mark;

            if (mark >= 40)
                passCount++;
        }

        Console.WriteLine("Student Marks Analysis");
        Console.WriteLine("----------------------");
        Console.WriteLine("Highest Marks : " + highest);
        Console.WriteLine("Lowest Marks  : " + lowest);
        Console.WriteLine("Passed Count  : " + passCount);
    }
}
