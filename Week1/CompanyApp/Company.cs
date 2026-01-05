using System;
namespace CompanyApp
{
    public class Company
    {
        public const string CompanyName = "Covalience";
        public readonly string RegistrationNumber;
        public static int TotalEmployees = 0;

        private string employeeName;
        private int employeeId;

        public Company(string registrationNumber, string employeeName, int employeeId)
        {
            this.RegistrationNumber = registrationNumber;
            this.employeeName = employeeName;
            this.employeeId = employeeId;
            TotalEmployees++;
        }

        public void DisplayDetails()
        {
            Console.WriteLine(CompanyName);
            Console.WriteLine(RegistrationNumber);
            Console.WriteLine(employeeName);
            Console.WriteLine(employeeId);
            Console.WriteLine(TotalEmployees);
        }
    }
}

