using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class Employee
{
    // ref keyword: updates salary
    public static void UpdateSalary(ref double salary)
    {
        salary = salary + (salary * 0.20);   // 20% increment
    }

    // out keyword: calculates bonus
    public static void CalculateBonus(double salary, out double bonus)
    {
        bonus = salary * 0.10;   // 10% bonus
    }
}


