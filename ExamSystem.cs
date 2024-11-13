namespace School_Exam_System
{
    class ExamSystem
    {
        private Dictionary<string, Exam> exams = new Dictionary<string, Exam>();

        public void TeacherMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--- Teacher Menu ---");
            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();

            string id = GetValidId("Enter your ID: ");  // Using the new method to validate ID input

            Teacher teacher = new Teacher(name, id);
            teacher.CreateExam(exams);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Exam created successfully by {teacher.Name}!");
        }

        // Method to handle ID input validation
        private string GetValidId(string prompt)
        {
            string id;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Green;
                id = Console.ReadLine().Trim();

                // Validate if the ID is a number
                if (int.TryParse(id, out _)) // Try parsing as an integer
                {
                    return id; // Return the valid ID
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! ID must be a number. Please try again.");
                }
            }
        }

        public void StudentMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--- Student Menu ---");
            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();

            string studentId = GetValidId("Enter your student ID: ");  // Using the new method to validate ID input

            Student student = new Student(name, studentId);
            student.TakeExam(exams);
        }
    }
}

