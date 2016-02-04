using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    public class Device
    {
        protected string name{get;set;}
        protected bool state{get;set;}
        protected string id{get;set;}

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
