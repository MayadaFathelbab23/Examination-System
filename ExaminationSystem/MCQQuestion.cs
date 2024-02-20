using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class MCQQuestion : Question
    {       
        public Answer[] Choices { get; set; }

        public MCQQuestion()
        {
            Header = "Choose One Answer Question";
            Choices = new Answer[3]; // index 0 For Rifgt Answer
                                     // index 1 fro User answer
            Answers = new Answer[2];
        }
       
        public override Question CreateQuestion()
        {
            int  rightChoice;
            string  choice1 , choice2 , choice3;          
            Console.WriteLine(Header);
            // create question body and mark
            SetQuestionBodyAndMark();
            // take question choices
            Console.WriteLine("The Choices of the Question");
            do
            {
                Console.Write("Enter The Choice Number 1 : ");
                choice1 = Console.ReadLine();
            } while (string.IsNullOrEmpty(choice1));
            Choices[0] = new Answer() { AnswerId = 1, AnswerText = choice1 };
            do
            {
                Console.Write("Enter The Choice Number 2 : ");
                choice2 = Console.ReadLine();
            } while (string.IsNullOrEmpty(choice2));
            Choices[1] = new Answer() { AnswerId = 2, AnswerText = choice2 };
            do
            {
                Console.Write("Enter The Choice Number 3 : ");
                choice3 = Console.ReadLine();
            } while (string.IsNullOrEmpty(choice3));
            Choices[2] = new Answer() { AnswerId = 3, AnswerText = choice3 };           
            do
            {
                Console.WriteLine("Please Specify The Right Choice of Qoestion");
            } while (!int.TryParse(Console.ReadLine(), out rightChoice) || !(rightChoice == 1 || rightChoice == 2 || rightChoice == 3));
           
            // Set Right Answer in last index of array
            if (rightChoice == 1)
                Answers[0] = new Answer() { AnswerId = 1, AnswerText = choice1 };
            else if(rightChoice == 2)
                Answers[0] = new Answer() { AnswerId = 2, AnswerText = choice2 };
            else if(rightChoice == 3)
                Answers[0] = new Answer() { AnswerId = 3, AnswerText = choice3 }; 
            return this;
        }
        public override void SetUserAnswer()
        {
            int answerId;
            bool flag = false;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out answerId);
            } while (!flag || !(answerId == 1 || answerId == 2 || answerId == 3));
            switch (answerId)
            {
                case 1:
                    Answers[1] = (Answer) Choices[0].Clone();
                    break;
                case 2:
                    Answers[1] = (Answer) Choices[1].Clone();
                    break;
                case 3:
                    Answers[1] = (Answer)Choices[2].Clone(); 
                    break;
            }
        }
        public override string ToString()
        {
            return $"{Header}   Mark({Mark})\n{Body}\n{Choices[0].AnswerId}. {Choices[0].AnswerText}\t{Choices[1].AnswerId}. {Choices[1].AnswerText}\t{Choices[2].AnswerId}. {Choices[2].AnswerText}";
        }
    }
}
