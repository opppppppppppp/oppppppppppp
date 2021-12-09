using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Memento
{
    class Originator
    {
        private string _backgroundImage;
        private string _backgroundImageName;
        private string _chatColor;
        private string _datetime;

        public Originator(string backgroundImage, string backgroundImageName, string chatColor, string datetime)
        {
            this._backgroundImage = backgroundImage;
            this._backgroundImageName = backgroundImageName;
            this._chatColor = chatColor;
            this._datetime = datetime;
        }

        public void SetSettings(string backgroundImage, string backgroundImageName, string chatColor, string datetime)
        {
            this._backgroundImage = backgroundImage;
            this._backgroundImageName = backgroundImageName;
            this._chatColor = chatColor;
            this._datetime = datetime;
        }

        public IMemento Save()
        {
            return new ConcreteMemento(_backgroundImage, _chatColor, _backgroundImageName, _datetime);
        }

        public void Restore(IMemento memento)
        {
            if(!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }
            this._backgroundImage = memento.GetBackgroundImage();
            this._chatColor = memento.GetChatColor();
            this._backgroundImageName = memento.GetBackgroundImage();
            this._datetime = memento.GetDate();
        }

    }
}
