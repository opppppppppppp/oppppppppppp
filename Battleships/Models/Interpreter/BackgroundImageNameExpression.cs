using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Interpreter
{
    class BackgroundImageNameExpression : AbstractExpression
    {
        public string Eveluate(string context)
        {
            string[] parts = context.Split(';');
            string color = parts[0].Split(':')[1];
            if (color == "r_")
                return "Red";
            if (color == "b_")
                return "Blue";
            return "Green";
        }
    }
}
