namespace Battleships.Models.Command
{
    public class SubtractScoreCommand : IScoreCommand
    {
        private int score;

        public SubtractScoreCommand(int score)
        {
            this.score = score;
        }

        public int Execute(int score)
        {
            return score - this.score;
        }

        public int Undo(int score)
        {
            return score + this.score;
        }
    }
}