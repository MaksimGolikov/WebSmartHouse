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
        public int Power;
        public List<string> help;

        public Fridge(string Name, bool State, bool stateFrize, int programm)
        {
            this.Name = Name;
            this.state = state;
            this.stateFrize = stateFrize;
            this.Power = programm;
            id = "Fridge";
        }

        public bool Switch()
        {
            this.state = !state;
            return state;
        }
        public void SwitchFrize()
        {
            stateFrize = !stateFrize;
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
            if (Power < 5)
                Power++;


        }
        public void ProgrammDown()
        {
            if (Power > 1)
                Power--;
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
