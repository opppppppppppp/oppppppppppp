using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Interpreter
{
    class Context
    {
        public string _expression { get; set; }
        public string _backgroundColor { get; set; }
        public string _chatColor { get; set; }

        public string _client { get; set; }

        public Context(string expression)
        {
            this._expression = expression;
            SetValues();
        }

        public string GetExpression()
        {
            return _expression;
        }

        public string GetBackgroundColor(string backgroundColor)
        {
            return _backgroundColor;
        }

        public string GetChatColor(string chatColor)
        {
            return _chatColor;
        }

        public string GetClient(string client)
        {
            return _client;
        }

        public void SetValues()
        {
            _backgroundColor = new BackgroundImageExpression().Eveluate(_expression);
            _chatColor = new ChatColorExpression().Eveluate(_expression);
        }




    }
}
