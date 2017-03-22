using System;
using System.Text;

namespace QuizTime
{
    public class LinearScale : Question
    {
        private readonly string text;
        private readonly int lowerBounds;
        private readonly int upperBounds;
        private readonly int correctAnswer;
        private int userAnswer;
        private bool hasAnswered = false;

        public override string Text
        {
            get { return text; }
        }

        public LinearScale(string text, int lowerBounds, int upperBounds, int correctAnswer)
        {
            this.text = text;
            this.lowerBounds = lowerBounds;
            this.upperBounds = upperBounds;
            this.correctAnswer = correctAnswer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("On a scale of {0:D} to {1:D}: ", lowerBounds, upperBounds))
                .Append(Text)
                .AppendLine();

            return sb.ToString();
        }

        public override void Answer(string guess)
        {
            userAnswer = Int32.Parse(guess);
            hasAnswered = true;
        }

        public override bool IsCorrect()
        {
            return hasAnswered && (userAnswer == correctAnswer);
        }

        public override bool ShouldAsk()
        {
            return !hasAnswered;
        }
    }
}