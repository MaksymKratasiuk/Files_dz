namespace Files_dz
{
    internal class Task5
    {
        public static void task5()
        {
            string filePath = "Task5.txt"; // Шлях до файлу з числами

            try
            {
                int positiveCount = 0;
                int negativeCount = 0;
                int twoDigitCount = 0;
                int fiveDigitCount = 0;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        int number = int.Parse(reader.ReadLine());

                        if (number > 0)
                            positiveCount++;
                        else if (number < 0)
                            negativeCount++;

                        if (number >= 10 && number <= 99)
                            twoDigitCount++;
                        else if (number >= 10000 && number <= 99999)
                            fiveDigitCount++;
                    }
                }

                Console.WriteLine("Статистика чисел:");
                Console.WriteLine("Кількість додатніх чисел: " + positiveCount);
                Console.WriteLine("Кількість від'ємних чисел: " + negativeCount);
                Console.WriteLine("Кількість двозначних чисел: " + twoDigitCount);
                Console.WriteLine("Кількість п'ятизначних чисел: " + fiveDigitCount);

                // Створення файлів з числами
                CreateNumberFile("Task5_pos.txt", filePath, n => n > 0);
                CreateNumberFile("Task5_neg.txt", filePath, n => n < 0);
                CreateNumberFile("Task5_two.txt", filePath, n => n >= 10 && n <= 99);
                CreateNumberFile("Task5_five.txt", filePath, n => n >= 10000 && n <= 99999);

                Console.WriteLine("Файли з числами створені.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        static void CreateNumberFile(string fileName, string sourceFilePath, Func<int, bool> predicate)
        {
            string targetFilePath = Path.GetDirectoryName(sourceFilePath) + "\\" + fileName;

            using (StreamWriter writer = new StreamWriter(targetFilePath))
            {
                using (StreamReader reader = new StreamReader(sourceFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        int number = int.Parse(reader.ReadLine());

                        if (predicate(number))
                            writer.WriteLine(number);
                    }
                }
            }
        }
    }
}

