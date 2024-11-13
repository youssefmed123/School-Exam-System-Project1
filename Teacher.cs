namespace School_Exam_System
{
    class Teacher : Person, IExamParticipant
    {
        public Teacher(string name, string id) : base(name, id) { }

        public void CreateExam(Dictionary<string, Exam> exams)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter exam number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string examNumber = Console.ReadLine();

            List<Question> questions = new List<Question>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose question type:");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. Handwriting");
                Console.WriteLine("3. Multiple Choice");
                Console.ForegroundColor = ConsoleColor.Green;
                string questionType = Console.ReadLine();

                if (questionType != "1" && questionType != "2" && questionType != "3")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid question type. Please choose 1, 2, or 3.");
                    continue; // Restart the loop for valid question type
                }

                string questionText = "";
                string answer = "";
                int questionGrade;
                List<string> options = new List<string>();

                if (questionType == "1") // True/False
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the question (True/False format): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    questionText = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the correct answer (True/False): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    answer = Console.ReadLine().Trim().ToLower();

                    if (answer != "true" && answer != "false")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid answer. Must be 'True' or 'False'.");
                        continue; // Restart the loop for valid answer
                    }
                }
                else if (questionType == "2") // Handwriting
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the handwriting question: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    questionText = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the expected answer: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    answer = Console.ReadLine();
                }
                else if (questionType == "3") // Multiple Choice
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the multiple choice question: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    questionText = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the options (type 'done' when finished):");

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        string option = Console.ReadLine();
                        if (option.ToLower() == "done")
                            break;
                        options.Add(option); // Add the option to the list
                    }

                    if (options.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You must enter at least one option.");
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the index of the correct answer (1 to " + options.Count + "): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int correctAnswerIndex = int.Parse(Console.ReadLine());

                    if (correctAnswerIndex < 1 || correctAnswerIndex > options.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid index.");
                        continue;
                    }

                    answer = options[correctAnswerIndex - 1];
                }

                // Input for grade
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter the grade for this question: ");
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        questionGrade = int.Parse(Console.ReadLine());
                        break; // Exit the loop on valid input
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

                // Add question to the list
                questions.Add(new Question(questionText, answer, questionGrade, options));

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Do you want to add another question? (y/n): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string addMore = Console.ReadLine().Trim().ToLower();
                if (addMore != "y") break; // Exit if teacher doesn't want to add more
            }

            exams[examNumber] = new Exam(questions);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Exam '{examNumber}' created successfully with {questions.Count} questions!");
        }
    }
}






