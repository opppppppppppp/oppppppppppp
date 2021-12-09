using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Interpreter
{
    class DateExpression : AbstractExpression
    {
        public string Eveluate(string context)
        {
            string[] parts = context.Split(';');
            return parts[2].Split(':')[1];
            
        }
    }
}
