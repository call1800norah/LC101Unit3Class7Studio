using System;
using System.Text;

namespace QuizTime
{
    public class ShortAnswer : Question
    {
        private readonly string text;
        private readonly string correctAnswer;
        private bool hasAnswered = false;
        private string userAnswer;
        
        public override string Text
        {
            get { return text; }
        }

        public ShortAnswer(string text, string correctAnswer)
        {
            this.text = text;
            this.correctAnswer = correctAnswer;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Answer the following question with a short answer.")
                .AppendLine("Your answer MUST be 80 characters or less, or you WILL be asked again.")
                .AppendLine()
                .Append("    ").Append(Text).AppendLine()
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