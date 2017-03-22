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

            Question q4 = new ShortAnswer(
                "What is Hamlet's most famous line?",
                "To Be or Not to Be"
            );
            quiz.AddQuestion(q4);

            Question q5 = new LinearScale(
                "How much wood could a woodchuck chuck if a woodchuck could chuck wood?",
                1,
                10,
                7
            );
            quiz.AddQuestion(q5);

            Question q6 = new ParagraphAnswer(
                "Which is better: Pirates or Ninjas? Justify your reasoning in a short paragraph.",
                "Pirates, obviously, they have rum. Q.E.D."
            );
            quiz.AddQuestion(q6);

            quiz.Run(new QuestionPrompt());
            ReportCard reportCard = quiz.Grade();

            Console.WriteLine(reportCard.ToString());
            Console.ReadLine();
        }
    }
}
