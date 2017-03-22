using System;

namespace QuizTime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            
            Question q1 = new MultipleChoice(
                "Who captained the Enterprise?",
                new []{"Kirk", "Scotty", "Kahn"},
                0
            );
            quiz.AddQuestion(q1);

            Question q2 = new Checkbox(
                "Which philosophers were exestential?",
                new []{"Kierkegaard", "Nietzsche", "Plato", "Hume"},
                new []{0, 1}
            );
            quiz.AddQuestion(q2);

            Question q3 = new TrueFalse(
                "Is the dollar bill fiat currency?",
                true
            );
            quiz.AddQuestion(q3);

            Question q4 = new ShortAnswerQuestion(
                "What is Hamlet's most famous line?",
                "To Be or Not to Be"
            );
            quiz.AddQuestion(q4);

            quiz.Run(new QuestionPrompt());
            ReportCard reportCard = quiz.Grade();

            Console.WriteLine(reportCard.ToString());
            Console.ReadLine();
        }
    }
}
