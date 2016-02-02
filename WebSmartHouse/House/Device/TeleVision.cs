using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class TeleVision : Device, IState
    {

        public string CurrentChanal;
        private int idChanel;
        private int Brightness;
        public List<string> help;
        private List<string> Chanel;

        public TeleVision(string Name, bool state, int brightness)
        {
            this.Name = Name;
            this.state = state;
            this.Brightness = brightness;

            id = "TV";


            Chanel = new List<string>();

            Chanel.Add("1+1");
            Chanel.Add("Интер");
            Chanel.Add("ТРК Украина");
            Chanel.Add("ТЕТ");
            Chanel.Add("Dicovery");
            Chanel.Add("Lion");
            Chanel.Add("ICTV");

            this.CurrentChanal = Chanel[0];
            idChanel = 0;
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
            return state;
        }


        public void ChangeUp()
        {

            if (idChanel < Chanel.Count - 1)
            {
                CurrentChanal = Chanel[idChanel + 1];
                idChanel++;
            }

        }
        public void ChangeDown()
        {
            if (idChanel > 0)
            {
                CurrentChanal = Chanel[idChanel - 1];
                idChanel--;
            }
        }

        public string ChuseChanal(int idChanel)
        {


            switch (idChanel)
            {
                case 0:
                    CurrentChanal = Chanel[0];
                    idChanel = 0;
                    break;
                case 1:
                    CurrentChanal = Chanel[1];
                    idChanel = 1;
                    break;
                case 2:
                    CurrentChanal = Chanel[2];
                    idChanel = 2;
                    break;
                case 3:
                    CurrentChanal = Chanel[3];
                    idChanel = 3;
                    break;
                case 4:
                    CurrentChanal = Chanel[4];
                    idChanel = 4;
                    break;
                case 5:
                    CurrentChanal = Chanel[5];
                    idChanel = 5;
                    break;
                case 6:
                    CurrentChanal = Chanel[6];
                    idChanel = 6;
                    break;

            }


            return CurrentChanal;
        }

        public void BrightnesUp()
        {
            if (this.Brightness < 100)
                this.Brightness += 5;


        }
        public void BrightnesDown()
        {
            if (this.Brightness > 5)
                this.Brightness -= 5;


        }

        public string ReturnBrightness()
        {
            return Convert.ToString(this.Brightness);
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
            val = "N next chanal";
            help.Add(val);
            val = "C Chuse chanal";
            help.Add(val);
            val = "P past chanal";
            help.Add(val);
            val = "BR for change brightness";
            help.Add(val);
            val = "del for delete";
            help.Add(val);
            val = "Press anykey for continue";
            help.Add(val);
            return help;

        }
    }
}
