using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    public class Device
    {
        protected string name;
        protected bool state;
        protected string id;

        public string GetName()
        {
            return this.name;
        }
        public bool GetState()
        {
            return this.state;
        }
        public string GetId()
        {
            return this.id;
        }
    }
}
