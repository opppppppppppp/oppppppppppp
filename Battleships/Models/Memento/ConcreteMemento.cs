using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Memento
{
    class ConcreteMemento : IMemento
    {
        private string _backgroundImage;
        private string _chatColor;
        private DateTime _date;

        public ConcreteMemento(string backgroundImage, string chatColor)
        {
            this._backgroundImage = backgroundImage;
            this._chatColor = chatColor;
            this._date = DateTime.Now;
        }

        public string GetBackgroundImage()
        {
            return _backgroundImage;
        }

        public string GetBackChatColor()
        {
            return _chatColor;
        }

        public string GetName()
        {
            return $"{this._date} / ({this._backgroundImage})...";
        }

        public string GetChatColor()
        {
            return _chatColor;
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
}
