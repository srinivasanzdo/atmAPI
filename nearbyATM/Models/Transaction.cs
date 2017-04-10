using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nearbyATM.Models
{
    public class Transaction
    {
        public int transactionid
        {
            get;
            set;
        }
        public int bankid
        {
            get;
            set;
        }
        public string mode
        {
            get;
            set;
        }
        public float amount
        {
            get;
            set;
        }
        public string transactiondate
        {
            get;
            set;
        }
    }
}