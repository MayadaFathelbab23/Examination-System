using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class FinalExam : Exam
    {
        private Question[] questions;
        public Question[] Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        public FinalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
        {
            questions = new Question[_numberOfQuestions];
        }


        public override void CreateExamQuestions()
        {
            int typeOfQuestion;
            for(int i = 0; i < questions.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Please choose the type of question number {i + 1} (1 for True Or False || 2 for MCQ");
                }while(!int.TryParse(Console.ReadLine() , out typeOfQuestion) || !(typeOfQuestion == 1 || typeOfQuestion == 2));
                // check question type
                Console.Clear();
                if (typeOfQuestion == 1)
                {
                    questions[i] = new TFQuestion();
                    questions[i] = questions[i].CreateQuestion();
                }
                else if (typeOfQuestion == 2)
                {
                    questions[i] = new MCQQuestion();
                    questions[i] = questions[i].CreateQuestion();
                }

            }
        }

        
       
        public override void ShowExam()
        {
            for(int i = 0;i < questions.Length;i++)
            {             
                Console.WriteLine(questions[i]);
                Console.WriteLine("--------------------------------");
                questions[i].SetUserAnswer();           
            }
            Console.WriteLine("Your Answers");
            for(int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Q{i + 1})   {questions[i].Body} : {questions[i].Answers[1].AnswerText}");
            }
            Console.WriteLine($"Your Grade is {Helper.GetStudentGrade(questions)} from {Helper.GetExamGrade(questions)}");
        }
    }
}
