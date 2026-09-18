using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exam01
{
    internal class FinalExam:Exam
    {
        #region Constructors
        public FinalExam(int time, int numberOfQuestions) : base(time , numberOfQuestions)
        { }
        #endregion

        #region Methods 

        public override void ShowExam()
        {
            Answer[] StudentAnswers = new Answer[Questions.Length];
            Stopwatch Sw = Stopwatch.StartNew();
            Console.WriteLine("Final Exam");
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i+1}: {Questions[i].QuestionHeader}");
                if (Questions[i].QuestionType == QuestionType.MCQ)
                {
                    Console.WriteLine($"MCQ Question:  Mark {Questions[i].Mark}");
                    for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                    {
                        Console.WriteLine($"{j+1}- {Questions[i].AnswerList[j].AnswerText}");
                    }
                    Console.WriteLine("Enter your answer ID:");
                    if (int.TryParse(Console.ReadLine(), out int Ans))
                    {
                        for (int j = 0; j < Questions[i].AnswerList.Length; j++)
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
                else
                {
                    Console.WriteLine($"True |False Question:  Mark {Questions[i].Mark}");
                    Console.WriteLine($"True/False Question: {Questions[i].QuestionBody}");
                    Console.WriteLine("1- True");
                    Console.WriteLine("2- False");
                    Console.WriteLine("Enter your answer ID:");
                    if (int.TryParse(Console.ReadLine(), out int Ans))
                    {
                        for (int j = 0; j < Questions[i].AnswerList.Length; j++)
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

            }
            Sw.Stop();
            Console.Clear();
            Console.WriteLine("Final Exam Results:");
            int FullGrade = 0;
            int? StudentGrade = 0;
            for (int i = 0; i < Questions.Length; i++)
            {
                FullGrade += Questions[i].Mark;
                Console.WriteLine($"Question {i + 1}: {Questions[i].QuestionBody}");
                Console.WriteLine($"Your Answer => {StudentAnswers[i]?.AnswerText ?? "No Answer"}");
                Console.WriteLine($"Correct Answer => {Questions[i].RightAnswer.AnswerText}");
                if (StudentAnswers[i]?.AnswerId == Questions[i].RightAnswer?.AnswerId)
                {
                    StudentGrade += Questions[i].Mark;
                }

               Console.WriteLine("");
            }
            Console.WriteLine($"Your Grade is {StudentGrade ?? 0} from {FullGrade}");
            Console.WriteLine($"Time = {Sw.Elapsed}");
            Console.WriteLine("Thank You");
        }

        public TrueFalseQuestion CreateTrueFalseQuestion()
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

            Answer[] Answers = new Answer[2];

            Answers[0] = new Answer(1, "True");
            Answers[1] = new Answer(2, "False");

            Console.WriteLine(
                "Please enter the ID of the correct answer (1 for True, 2 for False):"
            );

            if (!int.TryParse(Console.ReadLine(), out int AnswerId))
            {
                Console.WriteLine("Invalid format");
                return null;
            }

            if (AnswerId < 1 || AnswerId > 2)
            {
                Console.WriteLine("Invalid Answer ID");
                return null;
            }

            return new TrueFalseQuestion(
                "True/False",
                QuestionBody,
                ExamMark,
                Answers,
                Answers[AnswerId - 1]
            );
        }
        #endregion
    }
}
