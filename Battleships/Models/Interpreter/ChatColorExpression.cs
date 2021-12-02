using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Interpreter
{
    class ChatColorExpression : AbstractExpression
    {
        public string Eveluate(string context)
        {
            string[] parts = context.Split(';');
            string color = parts[1].Split(':')[1];
            if (color == "0")
                return "white";
            return "black";
            
        }
    }
}
