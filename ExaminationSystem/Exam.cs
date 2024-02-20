using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class Exam
    {
		private protected int time;
        private protected int numberOfQuestions;
        public int Time
		{
			get { return time; }
			set { time = value > 0 ? value : throw new Exception("Exam time must be greater thna 0 minutes"); }
		}
        public int NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set { numberOfQuestions = value > 0 ? value : throw new Exception("number of question must be greater thna zero"); }
        }
        public Exam(int _time, int _numberOfQuestions)
        {
            Time = _time;
            NumberOfQuestions = _numberOfQuestions;
        }

        public abstract void ShowExam();
        public abstract void CreateExamQuestions();
      
    }
}
