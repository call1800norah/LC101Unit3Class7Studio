using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTime
{
    public class Checkbox : Question
    {
        private readonly string text;
        private readonly string[] possibleChoices;
        private readonly int[] correctAnswers;
        private readonly int noneOfTheAboveChoice;
        private readonly List<int> userAnswers = new List<int>();
        private bool hasFinishedAnswering = false;
        
        public override string Text
        {
            get { return text; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Text)
                .AppendLine()
                .AppendLine("Choose ANY of the answers below.")
                .AppendLine("Press 'q' to finish choosing answers.")
                .AppendLine();

            string flag;
            bool isChosen;

            // regular questions

            for (int i = 0; i < possibleChoices.Length; i += 1)
            {
                isChosen = userAnswers.Contains(i);
                if (isChosen)
                {
                    flag = "chosen";
                }
                else
                {
                    flag = "unchosen";
                }
                sb.AppendLine(String.Format("\t{0}: {1} ({2})", i, possibleChoices[i], flag));
            }

            // "none of the above"

            isChosen = userAnswers.Contains(noneOfTheAboveChoice);
            if (isChosen)
            {
                flag = "chosen";
            }
            else
            {
                flag = "unchosen";
            }
            sb.AppendLine(String.Format("\t{0}: {1} ({2})", noneOfTheAboveChoice, "None of the above", flag));

            return sb.ToString();
        }

        public override void Answer(string guess)
        {
            if (guess == "q")
            {
                hasFinishedAnswering = true;
                return;
            }

            // actual answer
            int numericGuess = Int32.Parse(guess);
            if (!userAnswers.Contains(numericGuess))
            {
                userAnswers.Add(numericGuess);
            }
        }

        public override bool IsCorrect()
        {
            if (!hasFinishedAnswering)
            {
                return false;
            }

            // "none of the above"
            if (correctAnswers.Length == 0 && userAnswers.Count == 1)
            {
                return userAnswers[0] == noneOfTheAboveChoice;
            }

            // actual answers
            return userAnswers.TrueForAll(answer => correctAnswers.Contains(answer)) &&
                   userAnswers.Count == correctAnswers.Length;
        }

        public Checkbox(string text, string[] possibleChoices, int[] correctAnswers)
        {
            this.text = text;
            this.possibleChoices = possibleChoices;
            this.correctAnswers = correctAnswers;
            // "none of the above" choice is always one more than the actual
            // number of choices
            this.noneOfTheAboveChoice = possibleChoices.Length;
        }

        public override bool ShouldAsk()
        {
            return !hasFinishedAnswering;
        }
    }
}