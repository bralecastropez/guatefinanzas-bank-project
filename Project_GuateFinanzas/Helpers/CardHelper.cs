using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Project_GuateFinanzas.Helpers
{
    public class CardHelper
    {
        private Random rdm = new Random();
        private const int visa = 4, master = 5,american = 3, discovery = 6;

        public Int64 GetNumberCreditCard(string type)
        {
            bool State = false;
            var Serie = "0";
            Int64 NumCard = 0;

            do
            {
                switch (type)
                {
                    case "AmericanExpress":
                        Serie = american + " " + GetFifteenNumbers();
                        break;
                    case "MasterCard":
                        Serie = master + " " + GetFifteenNumbers();
                        break;
                    case "Visa":
                        Serie = visa + " " + GetFifteenNumbers();
                        break;
                    case "Discovery":
                        Serie = discovery + " " + GetFifteenNumbers();
                        break;
                    default:
                        break;
                }

                if (ValidatorNum(Serie) == true)
                {
                    State = true;
                    NumCard = Convert.ToInt64(Serie.Replace(" ", "").Trim());
                }
            }
            while(State == false);

            return NumCard;
        }

        public Int64 GetNumberForDebitCard()
        { 
            var FirstSegment = rdm.Next(10000000, 99999999).ToString();
            var SecondSegment = rdm.Next(10000000, 99999999).ToString();

            var FullTrace = FirstSegment + " " + SecondSegment;

            return Convert.ToInt64(FullTrace.Replace(" ", ""));
        }

        public bool ValidatorNum(string num)
        {
            num = num.Trim().Replace(" ", "");

            if(Regex.IsMatch(num, @"/[^0-9 \-]+/´"))
            {
                return false;
            }
			int nCheck = 0, nDigit = 0;
			bool bEven = false;

			num = num.Replace(@"/\D/g", "");

			for (var n = num.Length - 1; n >= 0; n--) {
				var cDigit = num.Substring(n, 1);
				nDigit = Convert.ToInt32(cDigit, 10);
				if ( bEven ) {
					if ( (nDigit *= 2) > 9 ) {
						nDigit -= 9;
					}
				}
				nCheck += nDigit;
				bEven = !bEven;
			}

			return (nCheck % 10) == 0;
        }

        public Int64 GetFifteenNumbers()
        {
            var First = rdm.Next(1000000, 9999999);
            var Second = rdm.Next(10000000, 99999999);

            var Full = First + " " + Second;

            return (Convert.ToInt64(Full.Replace(" ", "")));
        }

        //public Int64 GetTwelveNumbers()
        //{
        //    var First = rdm.Next(100000, 999999);
        //    var Second = rdm.Next(100000, 999999);

        //    var Full = First + " " + Second;

        //    return (Convert.ToInt64(Full.Replace(" ", "")));
        //}
    }
}