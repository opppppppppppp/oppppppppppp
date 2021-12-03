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
        private string _backgroundImageName;
        private string _date;

        public ConcreteMemento(string backgroundImage, string chatColor, string backgroundImageName, string datetime)
        {
            this._backgroundImage = backgroundImage;
            this._backgroundImageName = backgroundImageName;
            this._chatColor = chatColor;
            this._date = datetime;
        }


        public string GetBackgroundImageName()
        {
            return _backgroundImageName;
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

        public string GetDate()
        {
            return this._date;
        }
    }
}
