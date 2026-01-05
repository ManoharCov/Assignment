using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CompanyApp;


namespace CompanyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // first question
            Company emp1 = new Company("REG-101", "Manohar", 1);
            Company emp2 = new Company("REG-101", "Sambhav", 2);

            emp1.DisplayDetails();
            emp2.DisplayDetails();


         // second question
        double salary = 50000;
        double bonus;   // no initialization required

        // ref requires initialized variable
        Employee.UpdateSalary(ref salary);

        // out does NOT require initialized variable
        Employee.CalculateBonus(salary, out bonus);

        Console.WriteLine("Updated Salary: " + salary);
        Console.WriteLine("Bonus: " + bonus);

            // third question
            SalarySlab.SalarySlabProgram();

            // fourth question
            MenuDrivenProgram.MenuDriven();

            // fifth question

            // Email validation
            string email = "test@example.com";
            Console.WriteLine("Email Valid: " + UtilityMethods.ValidateEmail(email));

            // Palindrome check
            int number = 121;
            Console.WriteLine("Is Palindrome: " + UtilityMethods.IsPalindrome(number));

            // Factorial using recursion
            int value = 5;
            Console.WriteLine("Factorial of " + value + " is: " + UtilityMethods.Factorial(value));


            //sixth question

            BillingService service = new BillingService();

            Console.WriteLine("Electricity Bill : " +
                service.CalculateElectricityBill(250));

            Console.WriteLine("Mobile Bill      : " +
                service.CalculateMobileBill(180, 70));

            Console.WriteLine("Internet Bill    : " +
                service.CalculateInternetBill(135));

            Console.WriteLine("Insurance Premium: " +
                service.CalculateInsurancePremium(45, 500000));


            //seventh question

                BankAccount account = new BankAccount("ACC12345", 5000);

                account.Deposit(2000);
                account.Withdraw(1500);

                Console.WriteLine("Account Number: " + account.AccountNumber);
                Console.WriteLine("Final Balance : " + account.Balance);


            //eighth question

            StudentMarksAnalysis.MarksAnalysis();


            //ninth question

            Product[] products = new Product[]
       {
            new Product(101, "Laptop", 75000),
            new Product(102, "Mobile", 30000),
            new Product(103, "Tablet", 25000),
            new Product(104, "Headphones", 5000)
       };

            // Search by Product ID
            int searchId = 102;
            bool found = false;

            Console.WriteLine("Search Result:");
            foreach (Product product in products)
            {
                if (product.ProductId == searchId)
                {
                    product.Display();
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Product not found");

            //  Display products above given price
            double minPrice = 20000;
            Console.WriteLine("\nProducts above price " + minPrice + ":");

            foreach (Product product in products)
            {
                if (product.Price > minPrice)
                    product.Display();
            }




            //tenth question

            List<EmployeeList> employees = new List<EmployeeList>();

            // Add employees
            employees.Add(new EmployeeList { Id = 1, Name = "Manohar", Salary = 50000 });
            employees.Add(new EmployeeList { Id = 2, Name = "Simranjit", Salary = 60000 });
            employees.Add(new EmployeeList { Id = 3, Name = "Sahabaz", Salary = 55000 });

            Console.WriteLine("All Employees:");
            Display(employees);

            // Update salary
            foreach (EmployeeList emp in employees)
            {
                if (emp.Id == 2)
                {
                    emp.Salary = 65000;
                    break;
                }
            }

            // Delete employee
            employees.RemoveAll(e => e.Id == 1);

            Console.WriteLine("\nAfter Update and Delete:");
            Display(employees);

            //eleventh question

            Dictionary();
        }

        public static void Display(List<EmployeeList> employees)
        {
            foreach (EmployeeList emp in employees)
            {
                Console.WriteLine(
                    $"Id: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}");
            }
        }




        static void Dictionary()
        {
            // Create dictionary
            Dictionary<int, string> users = new Dictionary<int, string>();

            // Add users (prevent duplicate keys)
            AddUser(users, 101, "Amit");
            AddUser(users, 102, "Ravi");
            AddUser(users, 101, "Suresh"); // duplicate key

            // Display all users
            Console.WriteLine("All Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"UserId: {user.Key}, Username: {user.Value}");
            }

            // Search using TryGetValue
            int searchUserId = 102;
            if (users.TryGetValue(searchUserId, out string username))
            {
                Console.WriteLine($"\nUser found: {username}");
            }
            else
            {
                Console.WriteLine("\nUser not found");
            }
        }

        static void AddUser(Dictionary<int, string> users, int userId, string username)
        {
            if (!users.ContainsKey(userId))
            {
                users.Add(userId, username);
                Console.WriteLine($"User added: {username}");
            }
            else
            {
                Console.WriteLine($"Duplicate UserId not allowed: {userId}");
            }
        }
    }
}

