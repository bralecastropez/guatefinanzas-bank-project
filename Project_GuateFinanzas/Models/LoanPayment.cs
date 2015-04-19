using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_GuateFinanzas.Models
{
    public class LoanPayment
    {
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Fee amount")]
        public double FeeAmount { get; set; }

        [Required]
        public double Amortization { get; set; }

        [Required]
        public double Interest { get; set; }

        [Required]
        [Display(Name = "Retired Capital")]
        public double RetiredCapital { get; set; }

        [Required]
        [Display(Name = "Payment Due Date")]
        public string PaymentDueDate { get; set; }

        [Required]
        public double Default { get; set; }

        [Required]
        public Enumeration.LoanPaymentState PaymentState { get; set; }

        [Required]
        public int LoanID { get; set; }

        public virtual Loan Loan { get; set; }
    }
}