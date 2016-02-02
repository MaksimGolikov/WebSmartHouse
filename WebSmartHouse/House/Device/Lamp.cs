using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Lamp : Device, IState
    {
        private int Brightness;
        private System.Drawing.Color ColorLight;

        public List<string> help;
        private List<System.Drawing.Color> Colors;



        public Lamp(string Name, bool state, int brightnes)
        {
            this.state = state;
            this.Name = Name;
            Brightness = brightnes;
            ColorLight = System.Drawing.Color.White;
            id = "Lamp";
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

        public int BrightnesUp()
        {
            if (this.Brightness < 100)
                this.Brightness += 5;

            return this.Brightness;
        }
        public int BrightnesDown()
        {
            if (this.Brightness > 10)
                this.Brightness += -5;

            return this.Brightness;
        }

        public string BrightnessRetutn()
        {
            return Convert.ToString(this.Brightness);
        }

        public void SelectColor(string idColor)
        {

            Colors = new List<System.Drawing.Color>();

            Colors.Add(System.Drawing.Color.White);
            Colors.Add(System.Drawing.Color.Green);
            Colors.Add(System.Drawing.Color.Blue);
            Colors.Add(System.Drawing.Color.Red);
            Colors.Add(System.Drawing.Color.Yellow);


            switch (idColor)
            {
                case "White":
                    ColorLight = Colors[0];
                    break;
                case "Green":
                    ColorLight = Colors[1];
                    break;
                case "Blue":
                    ColorLight = Colors[2];
                    break;
                case "Red":
                    ColorLight = Colors[3];
                    break;
                case "Yellow":
                    ColorLight = Colors[4];
                    break;

            }

        }

        public System.Drawing.Color ReturnColor()
        {
            return this.ColorLight;
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
            val = "BR for change brightness";
            help.Add(val);
            val = "CL for change light`s color";
            help.Add(val);
            val = "del for delete";
            help.Add(val);
            val = "Press anykey for continue";
            help.Add(val);

            return help;

        }
    }
}
