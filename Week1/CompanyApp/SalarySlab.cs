using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class SalarySlab
{
  public  static void SalarySlabProgram()
    {
        double basicSalary, hra, da, grossSalary;

        Console.Write("Enter Basic Salary: ");
        basicSalary = Convert.ToDouble(Console.ReadLine());

        if (basicSalary <= 10000)
        {
            hra = basicSalary * 0.20;
            da = basicSalary * 0.80;
        }
        else if (basicSalary <= 20000)
        {
            hra = basicSalary * 0.25;
            da = basicSalary * 0.90;
        }
        else
        {
            hra = basicSalary * 0.30;
            da = basicSalary * 0.95;
        }

        grossSalary = basicSalary + hra + da;

        Console.WriteLine("\nBasic Salary : " + basicSalary);
        Console.WriteLine("HRA          : " + hra);
        Console.WriteLine("DA           : " + da);
        Console.WriteLine("Gross Salary : " + grossSalary);
    }
}

