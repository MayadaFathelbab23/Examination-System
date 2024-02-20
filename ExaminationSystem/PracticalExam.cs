using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class PracticalExam : Exam
    {
        private MCQQuestion[] mcqQuestion;

        public PracticalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
        {
            mcqQuestion = new MCQQuestion[_numberOfQuestions];
        }

        public MCQQuestion[] MCQQuestion
        {
            get { return mcqQuestion; }
            set { mcqQuestion = value; }
        }

        public override void CreateExamQuestions()
        {
            for (int i = 0; i < mcqQuestion.Length; i++)
            {
                mcqQuestion[i] = new MCQQuestion();
                mcqQuestion[i].CreateQuestion();
            }
        }

        public override void ShowExam()
        {
            for (int i = 0; i < mcqQuestion.Length; i++)
            {
                Console.WriteLine(mcqQuestion[i]);
                Console.WriteLine("--------------------------------");
                mcqQuestion[i].SetUserAnswer();
            }
            Console.WriteLine("Model Answer");
            for (int i = 0; i < mcqQuestion.Length; i++)
            {
                Console.WriteLine($"Q{i + 1})   {mcqQuestion[i].Body} : {mcqQuestion[i].Answers[0].AnswerText}");
            }
        }
    }
}
