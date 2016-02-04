using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class TapeRecoder : Device, IState
    {
        private bool mode;
        private int voluem;
      

        public TapeRecoder(string name, bool state, bool isCdMod, int volume)
        {
            this.name = name;
            this.state = state;
            this.mode = isCdMod;
            this.voluem = volume;
            id = "TR";
        }

        public bool Switch()
        {
            if (this.state)
            {
                this.state = false;
            }
            else
            {
                this.state = true;
            }

            return this.state;
        }

        public bool Mode()
        {
            if (this.mode)
            {
                this.mode = false;
            }
            else
            {
                this.mode = true;
            }

            return this.mode;
        }

        public void VolumeUp()
        {
            if (voluem < 100)
                voluem++;
        }
        public void VolumeDown()
        {
            if (voluem > 0)
                voluem--;
        }
        public int GetVolume()
        {
            return this.voluem;
        }

        public override string ToString()
        {
            string state;
            if (this.state)
            {
                state = "Включен";
            }
            else
            {
                state = "Выключен";
            }


            return state;
        }
        public string StateMode()
        {
            string mode;
            if (this.mode)
                mode = "Radio";
            else
                mode = "CD";
            return mode;

        }



       
    }
}
