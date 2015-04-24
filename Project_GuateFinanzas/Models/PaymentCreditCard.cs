using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_GuateFinanzas.Models
{
    public class PaymentCreditCard
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Total Payment")]
        public Int64 PaymentAmount { get; set; }

        [Required]
        [Display(Name = "Principal Payment")]
        public Int64 PrincipalPayment { get; set; }

        [Required]
        public Int64 Interest { get; set; }

        public int? Default { get; set; }

        [Required]
        public string Location { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date To Pay Off")]
        [DisplayFormat(DataFormatString = "0:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateToPayOff { get; set; }

        [Required]
        public Int64 CreditCardID { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<MovementCreditCard> Movements { get; set; }
        public virtual ICollection<ManageStateCreditCard> ChangesStateCC { get; set; }
    }
}