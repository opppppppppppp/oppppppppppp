using System;
using System.Collections;
using System.Collections.Generic;

namespace Battleships.Models.Command
{
    public class ScoreCalculator
    {
        public int score { get; private set; }
        private Stack<IScoreCommand> history;
        public ScoreCalculator()
        {
            score = 0;
            history = new Stack<IScoreCommand>();
        }

        public void ExecuteCommand(IScoreCommand command)
        {
            score = command.Execute(score);
            history.Push(command);
        }
        public void Undo()
        {
            var command = history.Pop();
            score = command.Undo(score);
        }
    }
}