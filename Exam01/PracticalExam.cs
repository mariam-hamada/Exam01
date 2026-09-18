using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.Java;
using System.Text;

namespace Exam01
{
    internal class PracticalExam : Exam
    {
        #region Constructors
        public PracticalExam(int time, int numberOfQuestions): base(time, numberOfQuestions)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Answer[] StudentAnswers = new Answer[Questions.Length];
            Stopwatch Sw = Stopwatch.StartNew();
            Console.WriteLine( "Practical Exam");
            for (int i = 0; i < Questions.Length; i++) 
            {
                Console.WriteLine( $"Question {i+1}: {Questions[i].QuestionHeader}");
                Console.WriteLine( $"MCQ Question:  Mark {Questions[i].Mark}");
                for (int j= 0; j < Questions[i].AnswerList.Length ; j++)
                {
                    Console.WriteLine($"{j+1}- {Questions[i].AnswerList[j].AnswerText}");
                }
                Console.WriteLine( "Enter your answer ID:");
                if (int.TryParse(Console.ReadLine(), out int Ans))
                {
                    for(int j = 0; j < Questions[i].AnswerList.Length; j++)
                    {
                        if (Ans == Questions[i].AnswerList[j].AnswerId)
                        {
                            StudentAnswers[i] = new Answer(Ans, Questions[i].AnswerList[j].AnswerText);
                            break;
                        }
                    }
                }
                else
                    Console.WriteLine("Invalid format");

            }
            Sw.Stop();
            Console.Clear();
            Console.WriteLine( "Practical Exam Results:");
            int FullGrade = 0;
            int? StudentGrade = 0;
            for(int i =0; i<Questions.Length; i++)
            {
                FullGrade += Questions[i].Mark;
                Console.WriteLine( $"Question {i+1}: {Questions[i].QuestionBody}");
                Console.WriteLine($"Your Answer => {StudentAnswers[i]?.AnswerText ?? "No Answer"}");
                Console.WriteLine( $"Correct Answer => {Questions[i].RightAnswer.AnswerText}");
                Console.WriteLine();
                if(StudentAnswers[i]?.AnswerId == Questions[i]?.RightAnswer?.AnswerId)
                {
                    StudentGrade += Questions[i].Mark;
                }

            }
            Console.WriteLine($"Your Grade is {StudentGrade ?? 0} from {FullGrade}");
            Console.WriteLine($"Time = {Sw.Elapsed}");
            Console.WriteLine("Thank You");
        }
            

        #endregion
    }
}
