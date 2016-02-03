using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Fridge : Device, IState
    {
        private bool stateFrize;
        private int power;
        private List<string> help;

        public Fridge(string name, bool state, bool stateFrize, int programm)
        {
            this.name = name;
            this.state = state;
            this.stateFrize = stateFrize;
            this.power = programm;
            id = "Fridge";
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
        public bool SwitchFrize()
        {
            if (this.stateFrize)
            {
                this.stateFrize = false;
            }
            else
            {
                this.stateFrize = true;
            }

            return this.stateFrize;
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
        public string ToStringFrize()
        {
            string stateFrize;

            if (this.stateFrize)
            {
                stateFrize = "Включен";
            }
            else
            {
                stateFrize = "Выключен";
            }
            return stateFrize;
        }



        public void ProgrammUP()
        {
            if (power < 5)
                power++;
        }
        public void ProgrammDown()
        {
            if (power > 1)
                power--;
        }
        public int GetPower()
        {
            return this.power;
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
            val = "OfF  for switch off Frize";
            help.Add(val);
            val = "OnF  for switch on Frize";
            help.Add(val);
            val = "PR for change programm on cold";
            help.Add(val);
            val = "del for delete";
            help.Add(val);
            val = "Press anykey for continue";
            help.Add(val);

            return help;

        }
    }
}
