using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nearbyATM.DataAccess;
using nearbyATM.Models;

namespace nearbyATM.Controllers
{
    public class BankController : ApiController
    {
        private BankAccess objBankAccess = new BankAccess();

        [HttpPost]
        [ActionName("userlogin")]
        public HttpResponseMessage UserLogin([FromBody]Bank objBank)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.UserLogin(objBank));
        }

        [HttpGet]
        [ActionName("getbanklistselect")]
        public HttpResponseMessage GetBankListSelect()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.GetBankListSelect());
        }

        [HttpGet]
        [ActionName("getbanklist")]
        public HttpResponseMessage GetBankList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.GetBankList());
        }

        [HttpGet]
        [ActionName("getsinglebank")]
        public HttpResponseMessage GetSingleBank(int bankid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.GetSingleBank(bankid));
        }

        [HttpGet]
        [ActionName("getbanktransaction")]
        public HttpResponseMessage GetBankTransaction(int bankid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.GetBankTransaction(bankid));
        }

        [HttpGet]
        [ActionName("changepassword")]
        public HttpResponseMessage ChangePassword(string oldpassword, string newpassword, string username)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.ChangePassword(oldpassword, newpassword, username));
        }

        [HttpPost]
        [ActionName("banktransaction")]
        public HttpResponseMessage BankTransaction([FromBody]Transaction objTransaction)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objBankAccess.BnakTransaction(objTransaction));
        }
    }
}
