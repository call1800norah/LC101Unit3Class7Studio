namespace QuizTime
{
    public abstract class Question
    {
        public abstract string Text { get; }

        public new abstract string ToString();

        public abstract void Answer(string guess);

        public abstract bool IsCorrect();

        public abstract bool ShouldAsk();
    }
}