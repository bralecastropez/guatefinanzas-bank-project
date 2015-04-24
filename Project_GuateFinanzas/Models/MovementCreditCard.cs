using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_GuateFinanzas.Models
{
    public class MovementCreditCard
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Movement Date")]
        [DisplayFormat(DataFormatString = "hh:mm:ss:dd-MM-yyyy", ApplyFormatInEditMode = false)]
        public DateTime MovementDate { get; set; }

        [Required]
        [Display(Name = "Spent Amount")]
        public double SpentAmount { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public Enumeration.ActivityStatus State { get; set; }

        [Required]
        public Int64 CreditCardID { get; set; }

        public virtual CreditCard CreditCard { get; set; }
    }
}