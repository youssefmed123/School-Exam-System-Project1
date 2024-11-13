namespace School_Exam_System
{
    class Exam
    {
    public List<Question> Questions { get; private set; }
    private int totalGrade;

    public Exam(List<Question> questions)
    {
        Questions = questions;
        totalGrade = CalculateTotalGrade();
    }

    public int TotalGrade
    {
        get { return totalGrade; }
    }

    private int CalculateTotalGrade()
    {
        int total = 0;
        foreach (var question in Questions)
        {
            total += question.Grade;
        }
        return total;
    }
    }
}
