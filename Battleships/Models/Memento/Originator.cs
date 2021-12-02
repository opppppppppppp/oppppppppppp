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
        private string _chatColor;

        public Originator(string backgroundImage, string chatColor)
        {
            this._backgroundImage = backgroundImage;
            this._chatColor = chatColor;
        }

        public void SetSettings(string backgroundImage, string chatColor)
        {
            this._backgroundImage = backgroundImage;
            this._chatColor = chatColor;
        }

        public IMemento Save()
        {
            return new ConcreteMemento(_backgroundImage, _chatColor);
        }

        public void Restore(IMemento memento)
        {
            if(!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }
            this._backgroundImage = memento.GetBackgroundImage();
            this._chatColor = memento.GetChatColor();
        }

    }
}
