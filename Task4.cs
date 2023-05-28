using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_dz
{
    internal class Task4
    {
        public static void task4()
        {
            Console.WriteLine("Введіть назву файлу:");
            string filePath = Console.ReadLine() ;

            try
            {
                string lines = File.ReadAllText(filePath+".txt");
                lines.Reverse();
                

                string reversedFilePath = Path.GetFileName(filePath+ "_reversed.txt");
                File.WriteAllText(reversedFilePath, lines);

                Console.WriteLine("Файл успішно перевернуто і збережено в " + reversedFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
