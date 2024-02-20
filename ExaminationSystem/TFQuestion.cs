using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class TFQuestion : Question
    {

        public TFQuestion()
        {
            Header = "True | Flase Question";
            Answers = new Answer[2]; // index 0 for right answer
                                    // index 1 for user answer
        }
       
        public override Question CreateQuestion()
        {          
            int   trueOrFalse;
            Console.WriteLine(Header);
            SetQuestionBodyAndMark();
            do
            {
                Console.WriteLine("Please Enter The Right Answer of the question (1 for true | 2 for false)");
            } while (!int.TryParse(Console.ReadLine(), out trueOrFalse) || !(trueOrFalse == 1 || trueOrFalse == 2));          
            // Set Right Answer in last index of array
            if (trueOrFalse == 1)
                Answers[0] = new Answer() { AnswerId = 1, AnswerText = "True" };
            else if(trueOrFalse == 2)
                Answers[0] = new Answer() { AnswerId = 2, AnswerText = "False" };
            return this;
        }

        public override void SetUserAnswer()
        {
            int answerId;
            bool flag = false;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out answerId);
            } while (!flag || !(answerId == 1 || answerId == 2 ));
            switch (answerId)
            {
                case 1:
                    Answers[1] = new Answer() { AnswerId = 1 , AnswerText = "True"};
                    break;
                case 2:
                    Answers[1] = new Answer() { AnswerId = 1, AnswerText = "False" };
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Header}   Mark({Mark})\n{Body}\n1. True\t2. Flase";
        }
    }
}
