using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class TapeRecoder : Device, IState
    {
        public bool mode;
        public int voluem;
        public List<string> help;

        public TapeRecoder(string Name, bool state, bool IsCdMod, int volume)
        {
            this.Name = Name;
            this.state = state;
            this.mode = IsCdMod;
            this.voluem = volume;
            id = "TR";
        }

        public bool Switch()
        {
            this.state = !state;
            return state;
        }

        public bool Mode()
        {
            this.mode = !mode;
            return mode;
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
