using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Exam01
{
    internal class Subject
    {
        #region Properties
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public Exam ExamOfSubject { get; set; }

        #endregion

        #region Method 

        public void CreateExam()
        {
            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");

            if (!int.TryParse(Console.ReadLine(), out int ExamType))
            {
                Console.WriteLine("Invalid format");
                return;
            }
            else
            {
                if (ExamType != 1 && ExamType != 2)
                    Console.WriteLine("Invalid exam type");
                else
                {
                    Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");

                    if (!int.TryParse(Console.ReadLine(), out int ExamTime))
                    {
                        Console.WriteLine("Invalid format");
                        return;
                    }
                    else
                    {
                        if (ExamTime >= 30 && ExamTime <= 180)
                        {
                            Console.WriteLine("Please enter the number of questions:");

                            if (!int.TryParse(Console.ReadLine(), out int NumberOfQuestions))
                            {
                                Console.WriteLine("Invalid format");
                                return;
                            }

                            if (NumberOfQuestions <= 0)
                            {
                                Console.WriteLine("Number of questions must be greater than 0.");
                                return;
                            }
                            Console.Clear();


                            if (ExamType == 1)
                            {
                                ExamOfSubject = new PracticalExam(ExamTime, NumberOfQuestions);
                                for (int i = 0; i < NumberOfQuestions; i++)
                                {
                                    ExamOfSubject.Questions[i] = ExamOfSubject.CreateMcqQuestion();

                                    Console.Clear();
                                }

                                ExamOfSubject.StartExam();
                            }



                            else if (ExamType == 2)
                            {
                                ExamOfSubject = new FinalExam(ExamTime, NumberOfQuestions);

                                for (int i = 0; i < NumberOfQuestions; i++)
                                {
                                    Console.WriteLine($"Enter details for question {i+1}:");
                                    Console.WriteLine(
                                        "Choose question type: 1 for MCQ, 2 for True/False:"
                                    );

                                    if (!int.TryParse(Console.ReadLine(), out int QuestionType))
                                    {
                                        Console.WriteLine("Invalid format");
                                        return;
                                    }
                                    Console.Clear();


                                    if (QuestionType == 1)
                                    {
                                        ExamOfSubject.Questions[i] = ExamOfSubject.CreateMcqQuestion();

                                        Console.Clear();
                                    }
                                    else if (QuestionType == 2)
                                    {
                                      
                                            FinalExam finalExam = (FinalExam)ExamOfSubject;

                                            ExamOfSubject.Questions[i] =
                                                finalExam.CreateTrueFalseQuestion();
                                    }


                                    else
                                    {
                                        Console.WriteLine("Invalid question type");
                                        return;
                                    }

                                    Console.Clear();
                                }


                                ExamOfSubject.StartExam();
                            }

                        }

                        else
                        {
                            Console.WriteLine("Invalid exam time");
                        }
                    }
                }

            }

        }
        #endregion

    }
}