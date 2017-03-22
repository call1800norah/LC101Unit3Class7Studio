using System.Collections.Generic;

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
}