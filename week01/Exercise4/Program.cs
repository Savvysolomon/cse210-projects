using System;
using System.Collections.Generic;
using System.Linq;                

class Program
{
    static void Main(string[] args)
    {
        // create an empty list to store integers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // loop to collect numbers from user
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            // only add the number to list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // only perform calculations if the user actually entered numbers
        if (numbers.Count > 0)
        {
            // compute the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            // compute the average 
            double average = (double)sum / numbers.Count;

            // find the maximum or largest number
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            // find the smallest positive number (greater than 0)
            int smallestPositive = int.MaxValue; 
            bool foundPositive = false;

            foreach (int number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                    foundPositive = true;
                }
            }

            // sort the numbers in ascending order
            numbers.Sort();

            // print the results
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // print the smallest positive result if one exists
            if (foundPositive)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // print the sorted list
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered into the list.");
        }
    }
}
