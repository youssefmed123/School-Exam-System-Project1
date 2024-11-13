namespace School_Exam_System
{
    class Question
    {
        public string Text { get; private set; }
        public List<string> Options { get; set; }
        public string Answer { get; private set; }
        public int Grade { get; private set; }

        public Question(string text, string answer, int grade)
        {
            Text = text;
            Answer = answer;
            Grade = grade;
        }

        public Question(string text, string answer, int grade, List<string> options)
            : this(text, answer, grade)
        {
            Options = options;
        }
    }
}
