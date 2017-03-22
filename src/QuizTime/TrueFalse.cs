using System;
using System.Text;

namespace QuizTime
{
    public class TrueFalse : Question
    {
        private readonly string text;
        private readonly bool correctAnswer;
        private bool userAnswer;
        private bool hasAnswered = false;

        public override string Text
        {
            get { return text; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Text)
                .AppendLine()
                .AppendLine("Choose ONE of the answers below.")
                .AppendLine();

            sb.AppendLine(String.Format("\t{0}: {1}", 0, "false"));
            sb.AppendLine(String.Format("\t{0}: {1}", 1, "true"));

            return sb.ToString();
        }

        public override void Answer(string guess)
        {
            userAnswer = (Int32.Parse(guess) == 1);
            hasAnswered = true;
        }

        public override bool IsCorrect()
        {
            return hasAnswered && (userAnswer == correctAnswer);
        }

        public TrueFalse(string text, bool correctAnswer)
        {
            this.text = text;
            this.correctAnswer = correctAnswer;
        }

        public override bool ShouldAsk()
        {
            return !hasAnswered;
        }
    }
}