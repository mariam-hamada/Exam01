using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Exam01
{
    internal class Answer
    {
        #region Properties 
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        #endregion

        #region Constructors 
        public Answer(int answerID, string answerText) 
        {
            AnswerId = answerID;
            AnswerText = answerText;
        }
        #endregion

        #region Methods 
        public override string ToString()
        {
            return $"Answer Id: {AnswerId} , Answer Text: {AnswerText}";
        }
        #endregion


    }
}
