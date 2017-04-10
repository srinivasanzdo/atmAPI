using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nearbyATM.Models
{
    public class Bank
    {
        public int bankid
        {
            get;
            set;
        }
        public string bankname
        {
            get;
            set;
        }
        public string banksearchname
        {
            get;
            set;
        }
        public float amount
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
    }
}