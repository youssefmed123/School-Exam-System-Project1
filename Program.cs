namespace School_Exam_System
{
    class Program
    {
        static void Main(string[] args)
        {
            ExamSystem examSystem = new ExamSystem();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Teacher");
                Console.WriteLine("2. Student");
                Console.WriteLine("3. Exit");
                Console.ForegroundColor = ConsoleColor.Green;
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    examSystem.TeacherMenu();
                }
                else if (choice == "2")
                {
                    examSystem.StudentMenu();
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
