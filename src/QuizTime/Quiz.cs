using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime
{
    public class Quiz
    {
        private readonly List<Question> questions = new List<Question>();

        public Quiz()
        {
        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public void Run(QuestionPrompt prompt)
        {
            foreach (Question question in questions)
            {
                while (question.ShouldAsk())
                {
                    string answer = prompt.Ask(question);
                    question.Answer(answer);
                }
            }
        }

        public ReportCard Grade()
        {
            return new ReportCard(questions);
        }
    }

    public class ReportCard
    {
        private readonly StringBuilder builder = new StringBuilder();

        public decimal Grade { get; private set; }

        public ReportCard(List<Question> questions)
        {
            decimal numberOfQuestions = questions.Count;
            decimal numberCorrect = 0;
            string flag;

            builder.AppendLine();

            foreach (Question question in questions)
            {
                flag = "INCORRECT";
                if (question.IsCorrect())
                {
                    numberCorrect += 1;
                    flag = "CORRECT  ";
                }

                builder.AppendLine(String.Format("{0} {1}", flag, question.Text));
            }

            Grade = numberCorrect / numberOfQuestions;

            builder.AppendLine().AppendLine(String.Format("Your grade: {0:P1}", Grade));
        }

        public override string ToString()
        {
            return builder.ToString();
        }
    }
}