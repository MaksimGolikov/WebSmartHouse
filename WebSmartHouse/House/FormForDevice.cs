using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebSmartHouse
{
    public class FormForDevice : Panel
    {

        #region Переменные

        // состояние устройства Вкл/Выкл
        private Button StateButton;
        private Label State;

        //яркость
        private Label BrightnessVolue;
        private Button BrightnessUp;
        private Button BrightnessDown;
        // Цвет
        private DropDownList ColorVolue;
        private Label ColorLight;
        //Канал
        private Label CurrentChanel;
        private DropDownList ChооseChanel;
        private Button ChanelUp;
        private Button ChanelDown;
        //Заморозка
        private Label ProgramFridge;
        private Button ProgramFridgeUp;
        private Button ProgramFridgeDown;
        private Button FrizeButton;
        private Label FrizeState;
        //Кондиционер
        private Label ProgramCond;
        private Button ProgramCondUp;
        private Button ProgramCondDown;

        private Button deleteButton;
        //Режим
        private Button ModeTR;
        private Label ModeState;
        //Громкость
        private Label Volume;
        private Button VolumeUp;
        private Button VolumeDown;



        private int id;  // номер устройства
        private IDictionary<int, Device> AllDeviceList;  //список устройств

        #endregion

        public FormForDevice(int id, IDictionary<int, Device> allDeviceList)
        {
            this.AllDeviceList = allDeviceList;
            this.id = id;
            Initializer();
        }


        //Инициализатор графики
        protected void Initializer()
        {
            CssClass = "Devicediv";
            Controls.Add(Span("Name: " + AllDeviceList[id].Name + "<br />"));

            StateButton = new Button();
            StateButton.Text = "Вкл/Выкл";
            StateButton.Click += StateButtonClick;
            Controls.Add(StateButton);


            switch (AllDeviceList[id].id)
            {
                case "Lamp":

                    InitializLamp();
                    break;

                case "Fridge":

                    InitializFridge();
                    break;

                case "TR":

                    InitializTR();
                    break;

                case "Cond":

                    InitializCond();
                    break;

                case "TV":

                    InitializTV();
                    break;

                case "Kettle":

                    InitializKettle();
                    break;
            }



            Controls.Add(Span("<br />"));

            deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Click += DeleteButtonClick;
            Controls.Add(deleteButton);

        }




        //Создание элементов    
        private DropDownList DropDownList(string selectId, List<string> value)
        {
            DropDownList lb = new System.Web.UI.WebControls.DropDownList();
            lb.AutoPostBack = true;
            lb.Width = 70;
            lb.Height = 20;
            for (int i = 0; i < value.Count; i++)
            {
                lb.Items.Add(value[i]);
            }

            lb.ID = selectId + id.ToString();
            lb.SelectedIndexChanged += ListBoxChanged;
            lb.Enabled = false;

            return lb;
        }
        private Label Label(string Text, string SelectID)
        {
            Label lab = new Label();
            lab.Text = Text;
            lab.ID = SelectID + id.ToString();
            return lab;
        }
        private Button Button(string selectid, string TextButt, int width, int height)
        {
            Button but = new Button();
            but.Enabled = false;
            but.Text = TextButt;
            but.ID = selectid + id.ToString();
            but.Width = width;
            but.Height = height;
            but.Click += ButtonClick;

            return but;
        }
        private TextBox TextBox(string SelectID)
        {
            TextBox Tb = new System.Web.UI.WebControls.TextBox();
            Tb.ID = SelectID + id.ToString();
            Tb.Width = 80;
            Tb.Height = 10;

            return Tb;
        }
        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

        //Обработка событий
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            AllDeviceList.Remove(id); // Удаление фигуры из коллекцию
            Parent.Controls.Remove(this); // Удаление графики для фигуры
        }
        private void StateButtonClick(object sender, EventArgs e)
        {
            switch (AllDeviceList[id].id)
            {
                case "Lamp":
                    ((Lamp)AllDeviceList[id]).Switch();
                    string st = ((Lamp)AllDeviceList[id]).ToString();
                    State.Text = st;

                    BrightnessUp.Enabled = ((Lamp)AllDeviceList[id]).state;
                    BrightnessDown.Enabled = ((Lamp)AllDeviceList[id]).state;
                    ColorVolue.Enabled = ((Lamp)AllDeviceList[id]).state;

                    break;

                case "Fridge":
                    ((Fridge)AllDeviceList[id]).Switch();
                    string ft = ((Fridge)AllDeviceList[id]).ToString();
                    State.Text = ft;

                    FrizeButton.Enabled = ((Fridge)AllDeviceList[id]).state;
                    ProgramFridgeDown.Enabled = ((Fridge)AllDeviceList[id]).state;
                    ProgramFridgeUp.Enabled = ((Fridge)AllDeviceList[id]).state;
                    break;

                case "Cond":
                    ((Conditioner)AllDeviceList[id]).Switch();
                    string ct = ((Conditioner)AllDeviceList[id]).ToString();
                    State.Text = ct;

                    ProgramCondDown.Enabled = ((Conditioner)AllDeviceList[id]).state;
                    ProgramCondUp.Enabled = ((Conditioner)AllDeviceList[id]).state;


                    break;

                case "TR":
                    ((TapeRecoder)AllDeviceList[id]).Switch();
                    string tt = ((TapeRecoder)AllDeviceList[id]).ToString();
                    State.Text = tt;

                    ModeTR.Enabled = ((TapeRecoder)AllDeviceList[id]).state;
                    VolumeDown.Enabled = ((TapeRecoder)AllDeviceList[id]).state;
                    VolumeUp.Enabled = ((TapeRecoder)AllDeviceList[id]).state;
                    break;

                case "Kettle":
                    ((Kettle)AllDeviceList[id]).Switch();
                    string kt = ((Kettle)AllDeviceList[id]).ToString();
                    State.Text = kt;
                    break;

                case "TV":
                    ((TeleVision)AllDeviceList[id]).Switch();
                    string vt = ((TeleVision)AllDeviceList[id]).ToString();
                    State.Text = vt;

                    ChanelUp.Enabled = ((TeleVision)AllDeviceList[id]).state;
                    ChanelDown.Enabled = ((TeleVision)AllDeviceList[id]).state;
                    ChооseChanel.Enabled = ((TeleVision)AllDeviceList[id]).state;
                    BrightnessUp.Enabled = ((TeleVision)AllDeviceList[id]).state;
                    BrightnessDown.Enabled = ((TeleVision)AllDeviceList[id]).state;
                    break;
            }

        }
        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {

                case "->":

                    if (AllDeviceList[id].state)
                    {
                        switch (AllDeviceList[id].id)
                        {
                            case "Lamp":

                                ((Lamp)AllDeviceList[id]).BrightnesUp();
                                BrightnessVolue.Text = ((Lamp)AllDeviceList[id]).BrightnessRetutn();
                                break;

                            case "Fridge":

                                ((Fridge)AllDeviceList[id]).ProgrammUP();
                                ProgramFridge.Text = Convert.ToString(((Fridge)AllDeviceList[id]).Power);
                                break;

                            case "TR":

                                ((TapeRecoder)AllDeviceList[id]).VolumeUp();
                                Volume.Text = Convert.ToString(((TapeRecoder)AllDeviceList[id]).voluem);
                                break;

                            case "Cond":

                                ((Conditioner)AllDeviceList[id]).ProgramUp();
                                ProgramCond.Text = ((Conditioner)AllDeviceList[id]).ProgramState();
                                break;

                            case "TV":

                                ((TeleVision)AllDeviceList[id]).BrightnesUp();
                                BrightnessVolue.Text = ((TeleVision)AllDeviceList[id]).ReturnBrightness();
                                break;

                        }

                    }
                    break;

                case "<-":

                    if (AllDeviceList[id].state)
                    {
                        switch (AllDeviceList[id].id)
                        {
                            case "Lamp":

                                ((Lamp)AllDeviceList[id]).BrightnesDown();
                                BrightnessVolue.Text = ((Lamp)AllDeviceList[id]).BrightnessRetutn();
                                break;

                            case "Fridge":

                                ((Fridge)AllDeviceList[id]).ProgrammDown();
                                ProgramFridge.Text = Convert.ToString(((Fridge)AllDeviceList[id]).Power);
                                break;

                            case "TR":

                                ((TapeRecoder)AllDeviceList[id]).VolumeDown();
                                Volume.Text = Convert.ToString(((TapeRecoder)AllDeviceList[id]).voluem);
                                break;

                            case "Cond":

                                ((Conditioner)AllDeviceList[id]).ProgramDown();
                                ProgramCond.Text = ((Conditioner)AllDeviceList[id]).ProgramState();
                                break;

                            case "TV":

                                ((TeleVision)AllDeviceList[id]).BrightnesDown();
                                BrightnessVolue.Text = ((TeleVision)AllDeviceList[id]).ReturnBrightness();
                                break;
                        }
                    }

                    break;

                case "Frize On/Off":

                    ((Fridge)AllDeviceList[id]).SwitchFrize();
                    FrizeState.Text = ((Fridge)AllDeviceList[id]).ToStringFrize();
                    break;

                case "Radio/CD":

                    ((TapeRecoder)AllDeviceList[id]).Mode();
                    ModeState.Text = ((TapeRecoder)AllDeviceList[id]).StateMode();

                    break;

                case "-->":

                    if (AllDeviceList[id].id == "TV" && AllDeviceList[id].state)
                    {
                        ((TeleVision)AllDeviceList[id]).ChangeUp();
                        CurrentChanel.Text = ((TeleVision)AllDeviceList[id]).CurrentChanal;
                    }

                    break;

                case "<--":

                    if (AllDeviceList[id].id == "TV" && AllDeviceList[id].state)
                    {
                        ((TeleVision)AllDeviceList[id]).ChangeDown();
                        CurrentChanel.Text = ((TeleVision)AllDeviceList[id]).CurrentChanal;
                    }

                    break;
            }
        }
        private void ListBoxChanged(object sender, EventArgs e)
        {

            if (AllDeviceList[id].id == "Lamp" && AllDeviceList[id].state)
            {
                ((Lamp)AllDeviceList[id]).SelectColor(Convert.ToString(ColorVolue.SelectedItem));
                ColorLight.BackColor = ((Lamp)AllDeviceList[id]).ReturnColor();
            }

            else if (AllDeviceList[id].id == "TV" && AllDeviceList[id].state)
            {
                ((TeleVision)AllDeviceList[id]).ChuseChanal(ChооseChanel.SelectedIndex);
                CurrentChanel.Text = ((TeleVision)AllDeviceList[id]).CurrentChanal;
            }
        }



        //Создание графики для каждого устройства
        private void InitializLamp()
        {
            Controls.Add(Span("      "));
            State = Label(((Lamp)AllDeviceList[id]).ToString(), "St");
            Controls.Add(State);
            Controls.Add(Span("<br/> "));

            Controls.Add(Span("Brightnes: "));
            Controls.Add(Span("           "));


            BrightnessVolue = Label(((Lamp)AllDeviceList[id]).BrightnessRetutn(), "Br");
            Controls.Add(BrightnessVolue);
            BrightnessUp = Button("UpBut", "<-", 30, 20);
            Controls.Add(BrightnessUp);


            BrightnessDown = Button("DowBut", "->", 30, 20);
            Controls.Add(BrightnessDown);

            List<string> color = new List<string>();
            string h;
            Controls.Add(Span("<br/> "));
            ColorLight = Label("Color light: ", "CI");
            Controls.Add(ColorLight);

            h = "White"; color.Add(h);
            h = "Green"; color.Add(h);
            h = "Blue"; color.Add(h);
            h = "Red"; color.Add(h);
            h = "Yellow"; color.Add(h);

            ColorVolue = DropDownList("Cl", color);
            Controls.Add(ColorVolue);


            ColorLight.BackColor = ((Lamp)AllDeviceList[id]).ReturnColor();
            BrightnessUp.Enabled = ((Lamp)AllDeviceList[id]).state;
            BrightnessDown.Enabled = ((Lamp)AllDeviceList[id]).state;
            ColorVolue.Enabled = ((Lamp)AllDeviceList[id]).state;

        }
        private void InitializFridge()
        {
            Controls.Add(Span("      "));
            State = Label(((Fridge)AllDeviceList[id]).ToString(), "St");
            Controls.Add(State);
            Controls.Add(Span("<br/> "));

            FrizeButton = Button("FrizBut", "Frize On/Off", 90, 20);
            FrizeState = Label(((Fridge)AllDeviceList[id]).ToStringFrize(), "Fr");
            Controls.Add(FrizeButton);
            Controls.Add(FrizeState);
            Controls.Add(Span("<br/> "));



            Controls.Add(Span("Programm: "));
            Controls.Add(Span("           "));


            ProgramFridge = Label(Convert.ToString(((Fridge)AllDeviceList[id]).Power), "PrFr");
            Controls.Add(ProgramFridge);
            ProgramFridgeUp = Button("UpButFr", "<-", 30, 20);
            Controls.Add(ProgramFridgeUp);


            ProgramFridgeDown = Button("DowButFr", "->", 30, 20);
            Controls.Add(ProgramFridgeDown);


            FrizeButton.Enabled = ((Fridge)AllDeviceList[id]).state;
            ProgramFridgeDown.Enabled = ((Fridge)AllDeviceList[id]).state;
            ProgramFridgeUp.Enabled = ((Fridge)AllDeviceList[id]).state;

        }
        private void InitializTR()
        {
            Controls.Add(Span("      "));
            State = Label(((TapeRecoder)AllDeviceList[id]).ToString(), "StTR");
            Controls.Add(State);
            Controls.Add(Span("<br/> "));

            ModeTR = Button("ModTR", "Radio/CD", 70, 20);
            ModeState = Label(((TapeRecoder)AllDeviceList[id]).StateMode(), "ModeTr");
            Controls.Add(ModeTR);
            Controls.Add(ModeState);
            Controls.Add(Span("<br/> "));


            Controls.Add(Span("Volume: "));
            Controls.Add(Span("           "));


            Volume = Label(Convert.ToString(((TapeRecoder)AllDeviceList[id]).voluem), "volTr");
            Controls.Add(Volume);
            VolumeUp = Button("VolUpBut", "<-", 30, 20);
            Controls.Add(VolumeUp);


            VolumeDown = Button("VolDowBut", "->", 30, 20);
            Controls.Add(VolumeDown);


            ModeTR.Enabled = ((TapeRecoder)AllDeviceList[id]).state;
            VolumeDown.Enabled = ((TapeRecoder)AllDeviceList[id]).state;
            VolumeUp.Enabled = ((TapeRecoder)AllDeviceList[id]).state;

        }
        private void InitializCond()
        {
            Controls.Add(Span("      "));
            State = Label(((Conditioner)AllDeviceList[id]).ToString(), "StCon");
            Controls.Add(State);
            Controls.Add(Span("<br/> "));


            Controls.Add(Span("Program: "));
            Controls.Add(Span("      "));
            ProgramCond = Label(((Conditioner)AllDeviceList[id]).ProgramState(), "ConPr");
            ProgramCondUp = Button("PrUp", "<-", 30, 20);

            Controls.Add(ProgramCond);
            Controls.Add(ProgramCondUp);

            ProgramCondDown = Button("PrDown", "->", 30, 20);
            Controls.Add(ProgramCondDown);
            Controls.Add(Span("<br/> "));

            ProgramCondDown.Enabled = ((Conditioner)AllDeviceList[id]).state;
            ProgramCondUp.Enabled = ((Conditioner)AllDeviceList[id]).state;
        }
        private void InitializTV()
        {
            Controls.Add(Span("      "));
            State = Label(((TeleVision)AllDeviceList[id]).ToString(), "StTV");
            Controls.Add(State);
            Controls.Add(Span("<br/> "));



            Controls.Add(Span("Chanel: "));
            Controls.Add(Span("           "));


            CurrentChanel = Label(Convert.ToString(((TeleVision)AllDeviceList[id]).CurrentChanal), "ChTV");
            Controls.Add(CurrentChanel);

            ChanelDown = Button("DownChBut", "<--", 30, 20);
            Controls.Add(ChanelDown);
            ChanelUp = Button("UpChBut", "-->", 30, 20);
            Controls.Add(ChanelUp);
            Controls.Add(Span("Chanel: "));

            List<string> chanel = new List<string>();

            chanel.Add("1+1");
            chanel.Add("Интер");
            chanel.Add("ТРК Украина");
            chanel.Add("ТЕТ");
            chanel.Add("Dicovery");
            chanel.Add("Lion");
            chanel.Add("ICTV");

            ChооseChanel = DropDownList("Chl", chanel);
            Controls.Add(ChооseChanel);

            Controls.Add(Span("<br/> "));

            Controls.Add(Span("Brightnes: "));
            Controls.Add(Span("           "));

            BrightnessVolue = Label(((TeleVision)AllDeviceList[id]).ReturnBrightness(), "Br");
            Controls.Add(BrightnessVolue);

            BrightnessUp = Button("UpBut", "<-", 30, 20);
            Controls.Add(BrightnessUp);
            BrightnessDown = Button("DowBut", "->", 30, 20);
            Controls.Add(BrightnessDown);


            ChanelUp.Enabled = ((TeleVision)AllDeviceList[id]).state;
            ChanelDown.Enabled = ((TeleVision)AllDeviceList[id]).state;
            ChооseChanel.Enabled = ((TeleVision)AllDeviceList[id]).state;
            BrightnessUp.Enabled = ((TeleVision)AllDeviceList[id]).state;
            BrightnessDown.Enabled = ((TeleVision)AllDeviceList[id]).state;
        }
        private void InitializKettle()
        {
            Controls.Add(Span("      "));
            State = Label(((Kettle)AllDeviceList[id]).ToString(), "StKet");
            Controls.Add(State);
            Controls.Add(Span("<br/> "));


        }


    }
}