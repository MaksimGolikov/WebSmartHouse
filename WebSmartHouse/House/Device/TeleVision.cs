using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class TeleVision : Device, IState
    {

        private string currentChanal;
        private int idChanel;
        private int brightness;       
        private List<string> chanel;

        public TeleVision(string name, bool state, int brightness)
        {
            this.name = name;
            this.state = state;
            this.brightness = brightness;

            id = "TV";


            chanel = new List<string>();

            chanel.Add("1+1");
            chanel.Add("Интер");
            chanel.Add("ТРК Украина");
            chanel.Add("ТЕТ");
            chanel.Add("Dicovery");
            chanel.Add("Lion");
            chanel.Add("ICTV");

            this.currentChanal = chanel[0];
            idChanel = 0;
        }

        public bool Switch()
        {

            if(this.state)
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
            return state;
        }


        public void ChangeUp()
        {

            if (idChanel < chanel.Count - 1)
            {
                currentChanal = chanel[idChanel + 1];
                idChanel++;
            }

        }
        public void ChangeDown()
        {
            if (idChanel > 0)
            {
                currentChanal = chanel[idChanel - 1];
                idChanel--;
            }
        }

        public string ChuseChanal(int idChanel)
        {


            switch (idChanel)
            {
                case 0:
                    currentChanal = chanel[0];
                    idChanel = 0;
                    break;
                case 1:
                    currentChanal = chanel[1];
                    idChanel = 1;
                    break;
                case 2:
                    currentChanal = chanel[2];
                    idChanel = 2;
                    break;
                case 3:
                    currentChanal = chanel[3];
                    idChanel = 3;
                    break;
                case 4:
                    currentChanal = chanel[4];
                    idChanel = 4;
                    break;
                case 5:
                    currentChanal = chanel[5];
                    idChanel = 5;
                    break;
                case 6:
                    currentChanal = chanel[6];
                    idChanel = 6;
                    break;

            }


            return currentChanal;
        }

        public string GetChanel()
        {
            return this.currentChanal;
        }


        public void BrightnesUp()
        {
            if (this.brightness < 100)
                this.brightness += 5;


        }
        public void BrightnesDown()
        {
            if (this.brightness > 5)
                this.brightness -= 5;


        }

        public string ReturnBrightness()
        {
            return Convert.ToString(this.brightness);
        }

       
    }
}
