using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSmartHouse
{
    public partial class Defoult : System.Web.UI.Page
    {
        private IDictionary<int, Device> DeviceList;
        private string Filtr;

        private int id;
       

        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                DeviceList = (SortedDictionary<int, Device>)Session["Devices"];

            }
            else
            {
                DeviceList = new SortedDictionary<int, Device>();



                DeviceList.Add(0, new Lamp("Лампа 1", false, 50));
                DeviceList.Add(1, new Fridge("Холодильник 1", false, false, 1));
                DeviceList.Add(2, new TapeRecoder("Музыкальный центр 1", false, false, 20));
                DeviceList.Add(3, new Conditioner("Кондиционер 1", false, 2));
                DeviceList.Add(4, new TeleVision("Телевизор 1", false, 50));
                DeviceList.Add(5, new Kettle("Чайник 1", false));



                Session["Devices"] = DeviceList;
                Session["nextID"] = 6;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LampButt.Click += ChangeFiltre;
                FridgeButt.Click += ChangeFiltre;
                TapRiderButt.Click += ChangeFiltre;
                ConditionerButt.Click += ChangeFiltre;
                TVButt.Click += ChangeFiltre;
                KettleButt.Click += ChangeFiltre;
                AddDevice.Click += NewDevice;

            }

            Filtr = Convert.ToString(Session["Filtr"]);
            LoadDevices(Filtr);
        }

        public void NewDevice(object sender, EventArgs e)
        {
            int nextid = Convert.ToInt32(Session["nextID"]);
            Filtr = Convert.ToString(Session["Filtr"]);

            switch (Filtr)
            {
                case "Lamp":

                    Lamp newLamp;
                    newLamp = new Lamp("Лампа " + nextid, false, 50);
                    DeviceList.Add(nextid, newLamp);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, DeviceList));


                    break;

                case "Fridge":

                    Fridge newFridge;
                    newFridge = new Fridge("Холодильник " + nextid, false, false, 1);
                    DeviceList.Add(nextid, newFridge);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, DeviceList));

                    break;

                case "TR":

                    TapeRecoder newTR;
                    newTR = new TapeRecoder("Музыкальный центр " + nextid, false, false, 20);
                    DeviceList.Add(nextid, newTR);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, DeviceList));

                    break;

                case "Cond":

                    Conditioner newCond;
                    newCond = new Conditioner("Кондиционер " + nextid, false, 2);
                    DeviceList.Add(nextid, newCond);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, DeviceList));

                    break;

                case "TV":

                    TeleVision newTV;

                    newTV = new TeleVision("Телевизор " + nextid, false, 50);
                    DeviceList.Add(nextid, newTV);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, DeviceList));

                    break;

                case "Kettle":

                    Kettle newKettle;

                    newKettle = new Kettle("Чайник " + nextid, false);
                    DeviceList.Add(nextid, newKettle);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, DeviceList));

                    break;
            }



            nextid++;
            Session["nextID"] = nextid;
        }
        private void ChangeFiltre(object sender, EventArgs e)
        {

            switch (((Button)sender).ID)
            {
                case "LampButt":


                    Filtr = "Lamp";
                    Session["Filtr"] = Filtr;
                    DevicePanel.Controls.Clear();


                    for (int iD = 0; iD < DeviceList.Count; iD++)
                    {
                        if (DeviceList[iD].id == Filtr)
                        {
                            DevicePanel.Controls.Add(new FormForDevice(iD, DeviceList));
                        }
                    }



                    break;

                case "FridgeButt":

                    Filtr = "Fridge";

                    Session["Filtr"] = Filtr;
                    DevicePanel.Controls.Clear();

                    for (int iD = 1; iD < DeviceList.Count; iD++)
                    {
                        if (DeviceList[iD].id == Filtr)
                        {
                            DevicePanel.Controls.Add(new FormForDevice(iD, DeviceList));
                        }
                    }


                    break;

                case "TapRiderButt":

                    Filtr = "TR";


                    Session["Filtr"] = Filtr;
                    DevicePanel.Controls.Clear();

                    for (int iD = 1; iD < DeviceList.Count; iD++)
                    {
                        if (DeviceList[iD].id == Filtr)
                        {
                            DevicePanel.Controls.Add(new FormForDevice(iD, DeviceList));
                        }
                    }



                    break;

                case "ConditionerButt":

                    Filtr = "Cond";


                    Session["Filtr"] = Filtr;
                    DevicePanel.Controls.Clear();

                    for (int iD = 1; iD < DeviceList.Count; iD++)
                    {
                        if (DeviceList[iD].id == Filtr)
                        {
                            DevicePanel.Controls.Add(new FormForDevice(iD, DeviceList));
                        }
                    }



                    break;

                case "TVButt":

                    Filtr = "TV";

                    Session["Filtr"] = Filtr;
                    DevicePanel.Controls.Clear();

                    for (int iD = 1; iD < DeviceList.Count; iD++)
                    {
                        if (DeviceList[iD].id == Filtr)
                        {
                            DevicePanel.Controls.Add(new FormForDevice(iD, DeviceList));
                        }
                    }


                    break;

                case "KettleButt":

                    Filtr = "Kettle";


                    Session["Filtr"] = Filtr;
                    DevicePanel.Controls.Clear();

                    for (int iD = 1; iD < DeviceList.Count; iD++)
                    {
                        if (DeviceList[iD].id == Filtr)
                        {
                            DevicePanel.Controls.Add(new FormForDevice(iD, DeviceList));
                        }
                    }

                    break;
            }
        }



        private void LoadDevices(string Filtr)
        {
            for (int key = 0; key < DeviceList.Count; key++)
            {
                if (DeviceList[key].id == Filtr)
                {
                    DevicePanel.Controls.Add(new FormForDevice(key, DeviceList));
                }

            }
        }








    }
}