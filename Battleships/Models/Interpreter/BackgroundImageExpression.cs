using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Interpreter
{
    class BackgroundImageExpression : AbstractExpression
    {
        public string Eveluate(string context)
        {
            string[] parts = context.Split(';');
            string color = parts[0].Split(':')[1];
            if (color == "r_")
                return "/Images/Settings/battleships_r.png";
            if (color == "b_")
                return "/Images/Settings/battleships.png";
           return "/Images/Settings/battleships_g.png";
        }
    }
}
