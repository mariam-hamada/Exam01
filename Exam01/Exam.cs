using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Exam01
{
    internal abstract class Exam
    {
        #region Properties
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        #endregion

        #region Constructors
        public Exam(int time , int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[NumberOfQuestions];
        }

        #endregion

        #region Methods
        public abstract void ShowExam();
        public McqQuestion? CreateMcqQuestion()
        {
            Console.WriteLine("Please enter the question body:");
            string QuestionBody = Console.ReadLine();

            Console.WriteLine("Please enter the question mark:");

            if (!int.TryParse(Console.ReadLine(), out int ExamMark))
            {
                Console.WriteLine("Invalid format");
                return null;
            }
            if (ExamMark <= 0)
            {
                Console.WriteLine("Question mark must be greater than 0.");
                return null;
               
            }
            Console.WriteLine("Choices of Question:");

            Answer[] Answers = new Answer[4];

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"Please enter choice number {j + 1}:");

                string AnswerText = Console.ReadLine();

                Answers[j] = new Answer(j + 1, AnswerText);
            }

            Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");

            if (!int.TryParse(Console.ReadLine(), out int AnswerId))
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            if (AnswerId < 1 || AnswerId > 4)
            {
                Console.WriteLine("Invalid Answer ID");
                return null;
            }

            return new McqQuestion(
                "MCQ",
                QuestionBody,
                ExamMark,
                Answers,
                Answers[AnswerId - 1]
            );
        }

        public void StartExam()
        {
            Console.WriteLine("Do You Want To Start Exam (Y | N)");

            if (char.TryParse(Console.ReadLine(), out char StartExam))
            {

                if (StartExam == 'Y' || StartExam == 'y')
                {


                    ShowExam();
                }
                else if (StartExam == 'N' || StartExam == 'n')
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            else
            {
                Console.WriteLine("Invalid format");
            }
        }

        #endregion
    }
}
