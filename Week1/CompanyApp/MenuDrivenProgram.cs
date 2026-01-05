using System;

class MenuDrivenProgram
{
   public static void MenuDriven()
    {
        int choice;
        double num1, num2;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter first number: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter second number: ");
                    num2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Result (Addition): " + (num1 + num2));
                    break;

                case 2:
                    Console.Write("Enter first number: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter second number: ");
                    num2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Result (Subtraction): " + (num1 - num2));
                    break;

                case 3:
                    Console.Write("Enter first number: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter second number: ");
                    num2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Result (Multiplication): " + (num1 * num2));
                    break;

                case 4:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }

        } while (choice != 4);
    }
}
