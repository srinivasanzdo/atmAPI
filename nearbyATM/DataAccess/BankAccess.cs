using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using nearbyATM.Models;
using nearbyATM.Core;

namespace nearbyATM.DataAccess
{
    public class BankAccess
    {
        public string UserLogin(Bank objBank)
        {
            return DbAccess.DbLogin("SELECT * FROM bank WHERE username='" + objBank.username + "' and password='" + objBank.password + "'");
        }

        public List<Dictionary<string, object>> GetBankListSelect()
        {
            return DbAccess.DbASelect("SELECT bankid, bankname FROM bank");
        }

        public List<Dictionary<string, object>> GetBankList()
        {
            return DbAccess.DbASelect("SELECT * FROM bank");
        }

        public List<Dictionary<string, object>> GetSingleBank(int bankid)
        {
            return DbAccess.DbASelect("SELECT * FROM bank where bankid="+bankid);
        }

        public List<Dictionary<string, object>> GetBankTransaction(int bankid)
        {
            return DbAccess.DbASelect("SELECT * FROM banktransaction where bankid=" + bankid);
        }

        public string ChangePassword(string oldpassword, string newpassword, string username)
        {
            string oldpasscheck = DbAccess.DbChangePassword("SELECT * FROM bank WHERE username='" + username + "'");

            if (oldpasscheck != "nil")
            {
                if (oldpasscheck != oldpassword)
                {
                    return "wrong";
                }
                else
                {
                    return DbAccess.DbAInsert("UPDATE bank SET password='" + newpassword + "' WHERE username='" + username + "'");
                }
            }
            else
            {
                return "nouser";
            }
        }

        public string BnakTransaction(Transaction objTransaction)
        {

            List<Bank> listbank = new List<Bank>();
            listbank = DbAccess.DbSingleBank("select * from bank where bankid='" + objTransaction.bankid + "'");

            float bal = listbank[0].amount;

            if (objTransaction.mode == "withdraw")
            {
                bal = bal - objTransaction.amount;
            }

            if (objTransaction.mode == "deposite")
            {
                bal = bal + objTransaction.amount;
            }
            
            string ret = DbAccess.DbAInsert("UPDATE bank SET amount='" + bal + "' WHERE bankid='" + objTransaction.bankid + "'");

            if (ret == "success")
            {

                return DbAccess.DbAInsert("insert into banktransaction VALUES ('NULL'," + objTransaction.bankid
                     + ", '" + objTransaction.mode
                     + "', '" + objTransaction.amount
                     + "', '" + objTransaction.transactiondate
                     + "')");
            }
            else
            {
                return "fail";
            }
        }
    }
}