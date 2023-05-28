using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_dz
{
    internal class Task1
    {
        public static void task1()
        {
            List<int> numbers = GenerateNumbers(100);

            // Запишемо прості числа в один файл
            List<int> primeNumbers = GetPrimeNumbers(numbers);
            WriteNumbersToFile(primeNumbers, "Task1_prime_numbers.txt");

            // Запишемо числа Фібоначчі в інший файл
            List<int> fibonacciNumbers = GetFibonacciNumbers(numbers);
            WriteNumbersToFile(fibonacciNumbers, "Task1_fibonacci_numbers.txt");

            // Виведемо статистику
            Console.WriteLine("Statistics:");
            Console.WriteLine($"Total numbers generated: {numbers.Count}");
            Console.WriteLine($"Prime numbers: {primeNumbers.Count}");
            Console.WriteLine($"Fibonacci numbers: {fibonacciNumbers.Count}");
        }

        static List<int> GenerateNumbers(int count)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int number = random.Next(1, 1000);
                numbers.Add(number);
            }

            return numbers;
        }

        static List<int> GetPrimeNumbers(List<int> numbers)
        {
            List<int> primeNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            }

            return primeNumbers;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static List<int> GetFibonacciNumbers(List<int> numbers)
        {
            List<int> fibonacciNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (IsFibonacci(number))
                {
                    fibonacciNumbers.Add(number);
                }
            }

            return fibonacciNumbers;
        }

        static bool IsFibonacci(int number)
        {
            double sqrt5 = Math.Sqrt(5);
            double phi = (1 + sqrt5) / 2;

            int a = (int)Math.Round(Math.Pow(phi, 2) * number);
            int b = (int)Math.Round(Math.Pow(phi, -2) * number);

            return (a * a == number || b * b == number);
        }

        static void WriteNumbersToFile(List<int> numbers, string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    using (var sw = new StreamWriter(fs))
                    {

                        foreach (var item in numbers)
                        {
                            sw.Write(item + " ");
                        }
                    }
                }

                Console.WriteLine("Масив успішно збережено у файлі.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при збереженні масиву у файл: " + ex.Message);
            }
        }

    }
}
