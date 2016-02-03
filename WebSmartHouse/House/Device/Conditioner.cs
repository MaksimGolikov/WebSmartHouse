using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Conditioner : Device, IState
    {
        private int programm;
        private List<string> help;

        public Conditioner(string name, bool state, int programm)
        {
            this.name = name;
            this.state = state;
            this.programm = programm;
            id = "Cond";
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


        public void ProgramUp()
        {
            if (programm < 3)
                programm++;
        }
        public void ProgramDown()
        {
            if (programm > 1)
                programm--;
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

            if (this.programm == 1)
            {
                program = "охлаждение";
            }
            else if (this.programm == 2)
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
