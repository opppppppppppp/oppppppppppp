namespace Battleships.Models.Command
{
    public interface IScoreCommand
    {
        int Execute(int score);

        int Undo(int score);
    }
}