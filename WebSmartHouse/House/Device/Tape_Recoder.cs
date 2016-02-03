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
        private List<string> help;

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



        public List<string> Help()
        {
            help = new List<string>();
            string val;

            val = "Доступные команды:";
            help.Add(val);
            val = "ON  for switch on";
            help.Add(val);
            val = "OFF  for switch off";
            help.Add(val);
            val = "CT for change time of alarm";
            help.Add(val);
            val = "del for delete";
            help.Add(val);
            val = "Press anykey for continue";
            help.Add(val);
            return help;

        }
    }
}
