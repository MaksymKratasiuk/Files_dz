using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_dz
{
    internal class Task2
    {
        public static void task2()
        {
            // Зчитуємо введені слова від користувача
            Console.Write("Введіть слово для пошуку: ");
            string searchWord = Console.ReadLine();

            Console.Write("Введіть слово для заміни: ");
            string replaceWord = Console.ReadLine();

            // Викликаємо метод для заміни входжень слова у файлі
            int replacements = ReplaceWordInFile(searchWord, replaceWord, "Task2.txt");

            // Виводимо статистику
            Console.WriteLine("Статистика:");
            Console.WriteLine($"Кількість замін: {replacements}");
        }
        static int ReplaceWordInFile(string searchWord, string replaceWord, string fileName)
        {
            string content = File.ReadAllText(fileName);
            string modifiedContent = content.Replace(searchWord, replaceWord);
            File.WriteAllText(fileName, modifiedContent);

            int replacements = CountReplacements(content, content);
            return replacements;
        }

        static int CountReplacements(string originalText, string modifiedText)
        {
            int count = 0;
            int currentIndex = 0;

            while ((currentIndex = modifiedText.IndexOf(originalText, currentIndex)) != -1)
            {
                count++;
                currentIndex += originalText.Length;
            }

            return count;
        }
    }
}
