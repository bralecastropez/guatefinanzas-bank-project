using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                string String_ = Serie.Trim();
                int St_Lenght = String_.Length;
                int Cypher = 0;
                int Sum = 0;
                int Iterator = 0;

                for (Iterator = 0; Iterator < St_Lenght; Iterator += 2)
                {
                    Cypher = int.Parse(String_.Substring(Iterator)) * 2;
                    if (Cypher > 9)
                    {
                        Cypher = Cypher - 9;
                    }
                    Sum += Cypher;
                }

                if (Sum % 10 == 0 && Sum < 150)
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