using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sb = new Subject(10, "C#");
            sb.CreateExam();
            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (Y | N) ");
            if(char.Parse(Console.ReadLine()) == 'Y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sb.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");

            }
        }
    }
}
