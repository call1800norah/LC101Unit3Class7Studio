using System;
using System.Text;

namespace QuizTime
{
    public class MultipleChoice : Question
    {
        private readonly string text;
        private readonly string[] possibleChoices;
        private readonly int correctAnswer;
        private int userAnswer;
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

            for (int i = 0; i < possibleChoices.Length; i += 1)
            {
                sb.AppendLine(String.Format("\t{0}: {1}", i, possibleChoices[i]));
            }

            return sb.ToString();
        }

        public override void Answer(string guess)
        {
            userAnswer = Int32.Parse(guess);
            hasAnswered = true;
        }

        public override bool IsCorrect()
        {
            return hasAnswered && userAnswer == correctAnswer;
        }

        public MultipleChoice(string text, string[] possibleChoices, int correctAnswer)
        {
            this.text = text;
            this.possibleChoices = possibleChoices;
            this.correctAnswer = correctAnswer;
        }

        public override bool ShouldAsk()
        {
            return !hasAnswered;
        }
    }
}