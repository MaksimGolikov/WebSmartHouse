using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Kettle : Device, IState
    {
        public List<string> help;



        public Kettle(string Name, bool state)
        {
            this.Name = Name;
            this.state = state;
            id = "Kettle";
        }

        public bool Switch()
        {
            this.state = !state;
            return state;
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
            return "состояние: " + state;
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
            val = "del for delete";
            help.Add(val);
            val = "Press anykey for continue";
            help.Add(val);

            return help;

        }
    }
}
