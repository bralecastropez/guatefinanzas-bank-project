using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_GuateFinanzas.Models
{
    public class Loan
    {
        [Display(Name = "Loan code")]
        public int ID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "0:dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Initial Loan Amount")]
        public double LoanAmount { get; set; }

        [Required]
        [Display(Name = "Loan Rate")]
        public int Rate { get; set; }

        [Required]
        [Display(Name = "Default Rate")]
        public int DefaultRate { get; set; }

        [Required]
        public Int64 AccountID { get; set; }

        public virtual BankAccount Account { get; set; }
        public virtual ICollection<LoanPayment> Payments { get; set; }
    }
}