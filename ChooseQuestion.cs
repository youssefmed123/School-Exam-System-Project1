using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Exam_System
{
    class ChooseQuestion : Question
    {
        public ChooseQuestion(string text, string answer, int grade, List<string> options)
            : base(text, answer, grade)
        {
            Options = options;
        }
    }

}
