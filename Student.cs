namespace School_Exam_System
{
    class Student : Person, IExamParticipant
    {
        public Student(string name, string id) : base(name, id) { }

        public void TakeExam(Dictionary<string, Exam> exams)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter exam number to take: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string examNumber = Console.ReadLine().Trim();

            // Check if the exam exists
            if (!exams.ContainsKey(examNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exam not found! Please ensure you entered the correct exam number.");
                return; // Exit if the exam is not found
            }

            Exam exam = exams[examNumber];
            int totalScore = 0;

            foreach (var question in exam.Questions)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{question.Text}");

                if (question.Options != null && question.Options.Count > 0)  // Check if it's a multiple-choice question
                {
                    for (int i = 0; i < question.Options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Options[i]}");
                    }
                    Console.Write("Enter the number of your answer: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string answer = Console.ReadLine().Trim();

                    if (int.TryParse(answer, out int answerIndex) && answerIndex > 0 && answerIndex <= question.Options.Count)
                    {
                        if (question.Options[answerIndex - 1].Trim().ToLower() == question.Answer.Trim().ToLower())
                        {
                            totalScore += question.Grade;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect answer.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid answer choice. Please select a valid option.");
                    }
                }
                else  // For True/False and Handwriting questions
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string answer = Console.ReadLine().Trim(); // Trimmed input
                    
                    // Compare answers for True/False or Handwriting questions
                    if (answer.ToLower() == question.Answer.ToLower())
                    {
                        totalScore += question.Grade;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect answer.");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name}, your total score is {totalScore} out of {exam.TotalGrade}.");
        }
    }
}

