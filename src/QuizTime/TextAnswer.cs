using System;
using System.Text;

namespace QuizTime
{
    public abstract class TextAnswer : Question
    {
        private readonly string text;
        private readonly string correctAnswer;
        private readonly int maxLength;
        private bool hasAnswered = false;
        private string userAnswer;
        
        public override string Text
        {
            get { return text; }
        }

        public TextAnswer(string text, string correctAnswer, int maxLength)
        {
            this.text = text;
            this.correctAnswer = correctAnswer;
            this.maxLength = maxLength;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Answer the following question with a short answer.")
                .AppendFormat("Your answer MUST be {0:D} characters or less, or you WILL be asked again.", maxLength)
                .AppendLine()
                .AppendLine()
                .AppendFormat("\"{0}\"", Text)
                .AppendLine();

            return sb.ToString();
        }

        public override void Answer(string guess)
        {
            if (guess.Length <= 80)
            {
                userAnswer = guess;
                hasAnswered = true;
            }
        }

        public override bool IsCorrect()
        {
            if (!hasAnswered)
            {
                return false;
            }

            int comparison = String.Compare(
                correctAnswer,
                userAnswer,
                StringComparison.OrdinalIgnoreCase
            );

            return comparison == 0;
        }

        public override bool ShouldAsk()
        {
            return !hasAnswered;
        }
    }
}