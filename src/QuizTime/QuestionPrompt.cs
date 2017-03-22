using System;

namespace QuizTime
{
    public class QuestionPrompt
    {
        public string Ask(Question question)
        {
            Console.WriteLine();
            Console.WriteLine(question.ToString());
            Console.Write("> ");
            string answer = Console.ReadLine().Trim();
            return answer;
        }
    }
}