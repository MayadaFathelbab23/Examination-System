using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class Question
    {
        #region Attributes
        // attributes
        private protected string? header;
        private protected string? body;
        private protected int mark;
        private protected Answer[]? answers;
        #endregion

        #region Properties
        public int Mark
        {
            get { return mark; }
            set { mark = value >= 0 ? value : 1; } 
        }
        public string Header
        {
            get { return header ?? ""; }
            set { header = string.IsNullOrEmpty(value) ? throw new Exception("Question Header Required") : value; }
        }
        public string Body
        {
            get { return body ?? ""; }
            set { body = string.IsNullOrEmpty(value) ? throw new Exception("Question Body Required") : value; }
        }
        public Answer[] Answers { get { return answers; } set { answers = value; } }
        #endregion
        public abstract Question CreateQuestion();
        public abstract void SetUserAnswer();
        public void SetQuestionBodyAndMark()
        {
            int mark;
            string _body;
            do
            {
                Console.WriteLine("Please Enter The Body Of the Question");
                _body = Console.ReadLine();
            } while (string.IsNullOrEmpty(_body));
            Body = _body;
            do
            {
                Console.WriteLine("Please Enter The Marks Of The Question");
            } while (!int.TryParse(Console.ReadLine(), out mark) || !(mark > 0));
            Mark = mark;
        }
        
    }
}
