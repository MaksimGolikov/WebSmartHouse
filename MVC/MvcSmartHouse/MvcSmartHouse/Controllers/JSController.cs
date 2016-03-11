using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


namespace MvcSmartHouse.Controllers
{
    public class JSController : Controller
    {
        //
        // GET: /JS/
        public ActionResult Index()
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            return View("~/Views/JS/Index.cshtml",deviceList);
        }

        public PartialViewResult VolumeDown(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IVolume)deviceList[id]).VolumeDown();
            Session["Devices"] = deviceList;



            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
           
        }

        public PartialViewResult VolumeUp(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IVolume)deviceList[id]).VolumeUp();
            Session["Devices"] = deviceList;




            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }


        public PartialViewResult BrightnessDown(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IBrightness)deviceList[id]).BrightnessDown();
            Session["Devices"] = deviceList;



            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }


        public PartialViewResult BrightnessUp(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IBrightness)deviceList[id]).BrightnessUp();
            Session["Devices"] = deviceList;

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }
            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }

        public PartialViewResult DVDstate(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            if (chanel == "diskbox")
            {
                ((Models.Devices.TeleVision)deviceList[id]).DVDcommand(chanel);
                Session["Devices"] = deviceList;
            }
            else if (chanel == "state")
            {
                ((Models.Devices.TeleVision)deviceList[id]).DVDcommand(chanel);
                Session["Devices"] = deviceList;
            }


            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);

        }
        public PartialViewResult Nextchanel(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IChanel)deviceList[id]).ChanelUp();
            Session["Devices"] = deviceList;

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }
            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }

        public PartialViewResult Beakchanel(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IChanel)deviceList[id]).ChanelDown();
            Session["Devices"] = deviceList;

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }
            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }

        public PartialViewResult Chusechanel(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IChanel)deviceList[id]).ChuseChanel(chanel);
            Session["Devices"] = deviceList;

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }
            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }

        public ActionResult SwitchMode(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IMode)deviceList[id]).ChangeMod();
            Session["Devices"] = deviceList;

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            return View("~/Views/SmartHouse/Index.cshtml", filtrDevice);
        }


        public PartialViewResult Switch([FromBody] int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            SelectListItem[] deviceListItem = (SelectListItem[])Session["DropDown"];

            ((Models.IState)deviceList[id]).Switch();

            Session["Devices"] = deviceList;


            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            //deviceListItem = (SelectListItem[])Session["DropDown"];
            //ViewBag.DeviceListItem = deviceListItem;

            return PartialView("~/Views/JS/Index.cshtml", filtrDevice);
        }
	}
}