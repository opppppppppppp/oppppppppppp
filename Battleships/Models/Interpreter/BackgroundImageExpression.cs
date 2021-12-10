using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Battleships.Models.Interpreter
{
    class BackgroundImageExpression : AbstractExpression
    {
        public string Eveluate(string context)
        {
            string[] parts = context.Split(';');
            string color = parts[0].Split(':')[1];
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            if (color == "r_")
                return path+"/Images/Settings/battleships_r.png";
            if (color == "b_")
                return path+"/Images/Settings/battleships.png";
           return path+"/Images/Settings/battleships_g.png";
        }
    }
}
