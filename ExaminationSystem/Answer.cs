using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Answer : ICloneable
    {
      
        private int answerId;
        private string? answerText;
           
        public int AnswerId
        {
            get { return answerId; }
            set { answerId = value >= 0 ? value : throw new Exception("Invalid Id Number"); }
        }
        public string AnswerText
        {
            get { return answerText ?? "" ; }
            set { answerText = string.IsNullOrEmpty(value) ? throw new Exception("Answer is Required") : value; }
        }

        public object Clone()
        {
            return new Answer()
            {
                AnswerText = this.AnswerText,
                AnswerId = this.AnswerId
            };
        }

        public static bool operator == (Answer a, Answer b)
        {
            return a.AnswerId == b.AnswerId && a.AnswerText == b.AnswerText;
        }
        public static bool operator !=(Answer a, Answer b)
        {
            return a.AnswerId != b.AnswerId || a.AnswerText != b.AnswerText;
        }
       

    }
}
