using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_dz
{
    internal class Task3
    {
        public static void task3()
        {
            Console.WriteLine("Введіть шлях до файлу з текстом:");
            string textFilePath = Console.ReadLine();

            Console.WriteLine("Введіть шлях до файлу зі словами для модерації:");
            string moderationFilePath = Console.ReadLine();

            try
            {
                string[] moderationWords = File.ReadAllLines(moderationFilePath);
                string text = File.ReadAllText(textFilePath);

                foreach (string word in moderationWords)
                {
                    string censoredWord = new string('*', word.Length);
                    text = text.Replace(word, censoredWord);
                }

                Console.WriteLine("Результат:");
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
