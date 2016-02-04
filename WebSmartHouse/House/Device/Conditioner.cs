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

        
    }
}
