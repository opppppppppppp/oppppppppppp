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
        public string _backgroundImageName { get; set; }
        public string _chatColor { get; set; }

        public string _date { get; set; }
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

        public string GetBackgroundColor()
        {
            return _backgroundColor;
        }public string GetBackgroundName()
        {
            return _backgroundImageName;
        }

        public string GetChatColor()
        {
            return _chatColor;
        }

        public string GetClient()
        {
            return _client;
        }

        public string GetDate()
        {
            return _date;
        }

        public void SetValues()
        {
            _backgroundColor = new BackgroundImageExpression().Eveluate(_expression);
            _chatColor = new ChatColorExpression().Eveluate(_expression);
            _backgroundImageName = new BackgroundImageNameExpression().Eveluate(_expression);
            _date = new DateExpression().Eveluate(_expression);
        }




    }
}
