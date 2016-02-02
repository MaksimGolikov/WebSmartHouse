using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Conditioner : Device, IState
    {
        private int Programm;
        public List<string> help;

        public Conditioner(string Name, bool state, int programm)
        {
            this.Name = Name;
            this.state = state;
            this.Programm = programm;
            id = "Cond";
        }

        public bool Switch()
        {
            this.state = !state;
            return state;
        }


        private void Hot()
        {
            Programm = 3;
        }
        private void Odinary()
        {
            Programm = 2;
        }
        private void Cold()
        {
            Programm = 1;
        }

        public void ProgramUp()
        {
            if (Programm < 3)
                Programm++;
        }
        public void ProgramDown()
        {
            if (Programm > 1)
                Programm--;
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
        public string ProgramState()
        {
            string program;

            if (this.Programm == 1)
            {
                program = "охлаждение";
            }
            else if (this.Programm == 2)
            {
                program = "проветривание";
            }
            else
            {
                program = "нагрев";
            }
            return program;
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
            val = "H for change programm on hot";
            help.Add(val);
            val = "S for change programm on odinary";
            help.Add(val);
            val = "O for change programm on odinary";
            help.Add(val);
            val = "del for delete";
            help.Add(val);
            val = "Press anykey for continue";
            help.Add(val);

            return help;

        }
    }
}
