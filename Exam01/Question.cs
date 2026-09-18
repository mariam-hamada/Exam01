using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01
{
    internal abstract class Question : ICloneable , IComparable
    {
        #region Properties  
        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public QuestionType QuestionType { get; set; }
        #endregion

        #region constructors 
        public Question(string questionHeader , string questionBody , int mark, Answer[] answerList , Answer rightAnswer)
        {
            QuestionHeader = questionHeader;
            QuestionBody = questionBody;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }
        #endregion

        #region Methods 
        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Question other = obj as Question;

            if (other == null)
                return 1;

            return Mark.CompareTo(other.Mark);
        }
        public override string ToString()
        {
            return QuestionBody;
        }
        #endregion
    }
}
