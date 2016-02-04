using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Kettle : Device, IState
    {
        


        public Kettle(string name, bool state)
        {
            this.name = name;
            this.state = state;
            id = "Kettle";
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
            return  state;
        }


        
    }
}
