namespace Files_dz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch = 0;

            do
            {
                Console.WriteLine("enter task->");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Task1.task1();
                        break;
                    case 2:
                        Task2.task2();
                        break;
                    case 3:
                        Task3.task3();
                        break;
                    case 4:
                        Task4.task4();
                        break;
                    case 5:
                        Task5.task5();
                        break;

                }

            } while (true);

            //Task1.task1();
            // Task2.task2();
            //Task3.task3();
            //Task4.task4();
        }
    }
}