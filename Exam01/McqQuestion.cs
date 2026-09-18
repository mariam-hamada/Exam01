using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01
{
    internal class McqQuestion:Question
    {

        #region Constructors
        public McqQuestion(string questionHeader, string questionBody, int mark, Answer[] answerList, Answer rightAnswer  ) : base(questionHeader, questionBody, mark, answerList, rightAnswer)
        {
            QuestionType = QuestionType.MCQ;
        }
        #endregion
    }
}
