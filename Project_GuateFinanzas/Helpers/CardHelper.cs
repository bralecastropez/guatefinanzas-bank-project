using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_GuateFinanzas.Helpers
{
    public class CardHelper
    {
        private Random rdm = new Random();
        private const int visa = 4, master = 5,american = 3, discovery = 6011;

        public Int64 GetNumberCreditCard(string type)
        { 
            switch (type)
            {
                case "American Express":
                    break;
                case "MasterCard":
                    break;
                case "Visa":
                    break;
                case "Discovery":
                    break;
                default:
                    break;
            }
        }
    }
}