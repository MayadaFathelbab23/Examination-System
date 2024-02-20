using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public static class Helper
    {
        public static int GetStudentGrade(Question[] questions)
        {
            int grade = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].Answers[0] == questions[i].Answers[1]) // compare right with user answer
                    grade += questions[i].Mark;
            }
            return grade;
        }
        public static int GetExamGrade(Question[] questions)
        {
            int grade = 0;
            foreach (var question in questions)
            {
                grade += question.Mark;
            }
            return grade;
        }
    }
}
