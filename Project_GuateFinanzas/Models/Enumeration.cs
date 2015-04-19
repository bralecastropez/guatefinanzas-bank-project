using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_GuateFinanzas.Models
{
    public class Enumeration
    {
        public enum AccountType
        { 
           Saving, Monetary 
        }

        public enum State
        { 
            Active, Inactive, Cancelled
        }

        public enum CreditCardType
        { 
            Visa, MasterCard, Credomatic, AmericanExpress
        }

        public enum TypeAccountActivity
        { 
            Withdraw, Deposit, Transfer, DebitCardWithdrawal
        }

        public enum ActivityStatus
        { 
            Successful, Failed
        }

        public enum RequestChangeStatus
        { 
            Lock, Unlock
        }

        public enum LoanPaymentState
        { 
            Overdue, UpToDate, Unauthorized, Authorized
        }
    }
}