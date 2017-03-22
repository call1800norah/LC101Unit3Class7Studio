namespace QuizTime
{
    public class ParagraphAnswer : TextAnswer
    {
        public ParagraphAnswer(string text, string correctAnswer) 
            : base(text, correctAnswer, 500)
        {
        }
    }
}