using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_GuateFinanzas.Models
{
    public class AccountMovement
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Movement date")]
        [DisplayFormat(DataFormatString = "hh:ss:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime MovementDate { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public Int64 AccountID { get; set; }

        [Display(Name = "Transaction type")]
        public Enumeration.TypeAccountActivity MovementType { get; set;}

        [Display(Name = "Transaction state")]
        public Enumeration.ActivityStatus ActivityState { get; set; }

        [Display(Name = "Target Account")]
        public Int64 TargetAccountID { get; set; }

        [Display(Name = "Check number or reference")]
        public Int64 CheckNumber { get; set; }
        
        public Int64 DebitCardNum { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 10)]
        public string Location { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual DebitCard DebitCard { get; set; }
        public virtual bool IsChecked { get; set; }

        //Request Change State Bank Account
        public virtual ICollection<RequestChangeState> RequestCSBA { get; set; }
    }
}