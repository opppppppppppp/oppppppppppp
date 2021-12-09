using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Interpreter
{
    interface AbstractExpression
    {
        string Eveluate(string context);
    }
}
