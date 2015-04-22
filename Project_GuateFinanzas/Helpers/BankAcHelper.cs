using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_GuateFinanzas.Helpers
{
    public class BankAcHelper
    {
        private Random rdm = new Random();

        public Int64 GetIDSavingAccount()
        {
            return rdm.Next(1000000, 9999999);
        }

        public Int64 GetIDMonetaryAccount()
        {
            var first = rdm.Next(1000000, 9999999);
            var second = rdm.Next(100, 999);

            var numString = first.ToString() + " " + second.ToString();

            var stringRep = numString.Replace(" ", "");

            return Convert.ToInt64(stringRep);
        }
    }
}