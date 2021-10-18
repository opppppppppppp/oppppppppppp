namespace Battleships.Models.Command
{
    public class AddScoreCommand : IScoreCommand
    {
        private int score;

        public AddScoreCommand(int score)
        {
            this.score = score;
        }

        public int Execute(int score)
        {
            return score + this.score;
        }

        public int Undo(int score)
        {
            return score - this.score;
        }
    }
}