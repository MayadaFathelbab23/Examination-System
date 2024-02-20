using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Subject
    {
		private int id;
		private string? name;
		private Exam exam;

		public Exam Exam
		{
			get { return exam; }
			set { exam = value; }
		}

		public int ID
		{
			get { return id; }
			set { id = value >= 0 ? value : throw new Exception("Invalid Subject ID"); }
		}

		public string Name
		{
			get { return name ?? ""; }
			set { name = string.IsNullOrEmpty(value) ? throw new Exception("Subject Name Required") : value; }
		}
        public Subject(int _id , string _name)
        {
            ID = _id;
			Name = _name;
        }
		public void CreateExam()
		{
			int typeOfExam , examTime , numberOfQuestions;
            // 1. create exam Final - Practical         
            do
			{
                Console.WriteLine("Please Enter the type of Exam You Want To Create (1 for Practical - 2 for Final");
            } while (!int.TryParse(Console.ReadLine(), out typeOfExam) || !(typeOfExam == 1 || typeOfExam == 2));

            do
            {
                Console.WriteLine("Please Enter the Time of Exam in Minutes");
            } while (!int.TryParse(Console.ReadLine(), out examTime) || !(examTime > 0));
            do
            {
                Console.WriteLine("Please Enter the Number of Questions You Want To Create");
            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || !(numberOfQuestions > 0));
			Console.Clear();
            //2.  check type of exam
            if (typeOfExam == 1)
				Exam = new PracticalExam(examTime , numberOfQuestions);
			else if(typeOfExam == 2)
				Exam = new FinalExam(examTime , numberOfQuestions);
			// 3. Create Questions
			Exam.CreateExamQuestions();
        }
    }
}
