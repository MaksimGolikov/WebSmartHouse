using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcSmartHouse.Controllers
{
    public class APIController : ApiController
    {
       [HttpPost]
        public IDictionary<int, Models.Devices.Device> Switch([FromBody]  IDictionary<int, Models.Devices.Device> device)
        {              
                   return device;
                 
        }
    }
}
