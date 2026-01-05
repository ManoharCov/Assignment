using System;
using System.Text.RegularExpressions;

class UtilityMethods
{
    //  Method to validate email
    public static bool ValidateEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }

    //  Method to check palindrome number
    public static bool IsPalindrome(int number)
    {
        int original = number;
        int reverse = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reverse = reverse * 10 + digit;
            number /= 10;
        }

        return original == reverse;
    }

    // Method to find factorial using recursion
    public static int Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * Factorial(n - 1);
    }
}

