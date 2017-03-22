namespace QuizTime
{
    public class ShortAnswer : TextAnswer
    {
        public ShortAnswer(string text, string correctAnswer) 
            : base(text, correctAnswer, 80)
        {
        }
    }
}